using ModuleTech.Core.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace ModuleTech.Core.Base.Concrete;

public abstract class BaseDbContext : DbContext
{

    public BaseDbContext(DbContextOptions<BaseDbContext> options)
        : base(options)
    {
    }

    protected BaseDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    [Obsolete("Use async implementation instead of this", true)]
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged))
            switch (entry.State)
            {
                case EntityState.Added when entry.Entity is IAuditableEntity entity:
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.CreatedBy = Guid.NewGuid();
                    break;
                case EntityState.Modified when entry.Entity is IAuditableEntity entity:
                    entity.UpdatedDate = DateTime.UtcNow;
                    entity.UpdatedBy = Guid.NewGuid();
                    break;
                case EntityState.Deleted when entry.Entity is ISoftDeleteEntity entity:
                    entry.State = EntityState.Modified;
                    entity.DeletedDate = DateTime.UtcNow;
                    entity.DeletedBy = Guid.NewGuid();
                    entity.IsDeleted = true;
                    break;
            }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged))
        {
            switch (entry.State)
            {
                case EntityState.Added when entry.Entity is IAuditableEntity entity:
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.CreatedBy = Guid.NewGuid();
                    break;
                case EntityState.Modified when entry.Entity is IAuditableEntity entity:
                    entity.UpdatedDate = DateTime.UtcNow;
                    entity.UpdatedBy = Guid.NewGuid();
                    break;
                case EntityState.Deleted when entry.Entity is ISoftDeleteEntity entity:
                    entry.State = EntityState.Modified;
                    entity.DeletedDate = DateTime.UtcNow;
                    entity.DeletedBy = Guid.NewGuid();
                    entity.IsDeleted = true;
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged))
        {
          //Audit Logs yazılabilir
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}