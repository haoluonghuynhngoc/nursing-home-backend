using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Hubs;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Infrastructure.Hubs;
using System.Text.Json;

namespace NursingHome.Infrastructure.Services.Notifications;

public class SignalRNotificationService : ISignalRNotificationService
{
    private readonly ILogger<SignalRNotificationService> _logger;
    private readonly IHubContext<NotificationHub, INotificationHub> _notificationHubContext;

    public SignalRNotificationService(
        ILogger<SignalRNotificationService> logger,
        IHubContext<NotificationHub, INotificationHub> notificationHubContext)
    {
        _logger = logger;
        _notificationHubContext = notificationHubContext;
    }

    public async Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default)
    {
        await _notificationHubContext.Clients.User(notification.UserId.ToString())
            .ReceiveNotification(notification);

        _logger.LogInformation($"[WEB NOTIFICATION] Send notification: {JsonSerializer.Serialize(notification)}");
    }
}