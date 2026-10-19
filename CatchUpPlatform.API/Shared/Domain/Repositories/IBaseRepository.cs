namespace CatchUpPlatform.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);
}