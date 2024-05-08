using NursingHome.Application.Models.Notifications;

namespace NursingHome.Application.Contracts.Hubs;
public interface INotificationHub
{
    Task ReceiveNotification(NotificationRequest notification);
}
