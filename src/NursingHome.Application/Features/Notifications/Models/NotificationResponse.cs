using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Notifications.Models;
public sealed record NotificationResponse : BaseAuditableEntityResponse<int>
{
    public string? Title { get; set; }
    public string Content { get; set; } = default!;
    public bool IsRead { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public string? Data { get; set; }

    [JsonIgnore]
    public Guid UserId { get; set; }
}
