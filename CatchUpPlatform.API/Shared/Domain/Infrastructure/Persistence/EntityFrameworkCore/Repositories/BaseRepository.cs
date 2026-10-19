using CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using CatchUpPlatform.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context = context;
    
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().FindAsync([id], cancellationToken);
    }
    

    public Task Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }       

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public Task<IEnumerable<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Context.Set<TEntity>().AsEnumerable());
    }
}