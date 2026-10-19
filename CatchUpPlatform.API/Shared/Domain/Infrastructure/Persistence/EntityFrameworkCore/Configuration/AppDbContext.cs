using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{ 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
    
}