using CatchUpPlatform.API.Shared.Domain.Model;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

public partial class FavoriteSourceAudit : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}