using CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class UnitOfWork(AppDbContext context)
{
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}