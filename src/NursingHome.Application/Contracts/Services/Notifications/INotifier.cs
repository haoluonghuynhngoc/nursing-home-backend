using NursingHome.Application.Models.Notifications;

namespace NursingHome.Application.Contracts.Services.Notifications;

public interface INotifier
{
    Task NotifyAsync(NotificationRequest notification, bool isSaved = true, CancellationToken cancellationToken = default);
}