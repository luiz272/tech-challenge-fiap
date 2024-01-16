
using Domain.Base;
using Domain.Repositories.common;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Common;

public abstract class EfRepository<TEntity> : RepositoryBase<TEntity>, IAsyncRepository<TEntity>
    where TEntity : BaseEntity, IAggregateRoot
{
    protected EfRepository(TechContext context) : base(context)
    {
    }

    public void Add(TEntity entity) =>
        DbSet.Add(entity);

    public void AddRange(IEnumerable<TEntity> entities) =>
        DbSet.AddRange(entities);

    public void Update(TEntity entity) =>
        DbSet.Update(entity);


    public void UpdateRange(IEnumerable<TEntity> entities) =>
        DbSet.UpdateRange(entities);

    public void Remove(TEntity entity) =>
        DbSet.Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        DbSet.RemoveRange(entities);

    public virtual async Task<TEntity> GetByIdAsync(Guid id, bool readOnly = false) =>
        readOnly ? await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id) : await DbSet.FindAsync(id);
}