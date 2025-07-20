using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Core.Base.Interface;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity?> GetById(object id, CancellationToken cancellationToken=default);
}