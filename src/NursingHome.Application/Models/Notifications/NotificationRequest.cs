using NursingHome.Domain.Enums;

namespace NursingHome.Application.Models.Notifications;
public sealed record NotificationRequest : BaseAuditableEntityResponse<int>
{
    public string? Title { get; set; }
    public string Content { get; set; } = default!;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public Guid UserId { get; set; }
    public string? Data { get; set; }
    public string? PhoneNumber { get; set; } = default!;

}
