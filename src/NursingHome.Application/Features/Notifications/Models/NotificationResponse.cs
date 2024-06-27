using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Notifications.Models;
public sealed record NotificationResponse : BaseAuditableEntityResponse<int>
{
    public string? Title { get; set; }
    public string Content { get; set; } = default!;
    public NotificationType Type { get; set; }
    public NotificationLevel Level { get; set; }
    public bool IsRead { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public string? Data { get; set; }

    [JsonIgnore]
    public Guid UserId { get; set; }
}
