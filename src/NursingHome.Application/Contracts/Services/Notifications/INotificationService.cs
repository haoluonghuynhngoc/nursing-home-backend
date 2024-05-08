using NursingHome.Application.Models.Notifications;

namespace NursingHome.Application.Contracts.Services.Notifications;

public interface INotificationService
{
    public Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default);
}