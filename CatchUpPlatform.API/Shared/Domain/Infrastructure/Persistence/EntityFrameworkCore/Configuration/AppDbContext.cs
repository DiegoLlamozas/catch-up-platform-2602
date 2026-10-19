using CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Shared.Domain.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntityInterceptor());   
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSnakeCaseNamingConvention();
    }
    
    
}