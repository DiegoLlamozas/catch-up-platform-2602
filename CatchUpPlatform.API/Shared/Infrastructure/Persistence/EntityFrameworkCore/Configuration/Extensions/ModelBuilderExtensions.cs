using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Convert table name to snake_case
            entity.SetTableName(entity.GetTableName()!.ToPlural().ToSnakeCase());

            // Convert column names to snake_case
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName()!.ToSnakeCase());
            }

            // Convert primary key names to snake_case
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()!.ToSnakeCase());
            }

            // Convert foreign key names to snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()!.ToSnakeCase());
            }

            // Convert index names to snake_case
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()!.ToSnakeCase());
            }
        }
    }
}