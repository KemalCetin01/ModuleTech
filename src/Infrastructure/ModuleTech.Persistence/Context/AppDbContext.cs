using ModuleTech.Core.Base.Concrete;
using ModuleTech.Domain;
using ModuleTech.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ModuleTech.Persistence.Context;

public class AppDbContext: BaseDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected DbSet<UserEmployee> UserEmployees { get; set; } = null!;
    protected DbSet<EmployeeRole> EmployeeRoles { get; set; } = null!;
    protected DbSet<UserB2B> UserB2Bs { get; set; } = null!;
    public DbSet<UserResetPassword> UserResetPasswords { get; set; } = null!;
    protected DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EmployeeRoleConfigurations());
        modelBuilder.ApplyConfiguration(new ProductConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new UserB2BConfigurations());
        modelBuilder.ApplyConfiguration(new UserEmployeeConfigurations());
        modelBuilder.ApplyConfiguration(new UserOTPConfigurations());
        modelBuilder.ApplyConfiguration(new UserResetPasswordConfigurations());

    }
}
//dotnet ef migrations add InitialCreate --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API
//dotnet ef database update --project src/Infrastructure/ModuleTech.Persistence --startup-project src/Presentation/ModuleTech.API