using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class UnitOfWork(AppDbContext context)
{
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}