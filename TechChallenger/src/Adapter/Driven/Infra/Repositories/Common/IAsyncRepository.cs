using Domain.Base;

namespace Domain.Repositories.common;

public interface IAsyncRepository<TEntity> : IRepository where TEntity : BaseEntity, IAggregateRoot
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}

public interface IRepository
{
}
