using Mapster;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Services.Notifications;

public class Notifier : INotifier
{
    private readonly INotificationProvider _provider;
    private readonly ILogger<Notifier> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public Notifier(
        INotificationProvider provider,
        ISignalRNotificationService signalRNotificationService,
        IFirebaseNotificationService firebaseNotificationService,
        ISmsNotificationService smsNotificationService,
        IExpoNotificationService expoNotificationService,
        ILogger<Notifier> logger,
        IUnitOfWork unitOfWork)
    {
        _provider = provider;
        _logger = logger;
        _unitOfWork = unitOfWork;

        _provider.Attach(new List<NotificationType>()
        {
            NotificationType.ExpoPush,
        }, expoNotificationService);

    }

    public async Task NotifyAsync(
        NotificationRequest notificationRequset,
        bool isSaved = true,
        CancellationToken cancellationToken = default)
    {

        if (isSaved)
        {
            var notification = notificationRequset.Adapt<Notification>();
            await _unitOfWork.Repository<Notification>().CreateAsync(notification, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            notification.Adapt(notificationRequset);
        }

        _logger.LogInformation($"[PUSH NOTIFICATION]: {notificationRequset}");
        await _provider.NotifyAsync(notificationRequset, cancellationToken);
    }
}