using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Infrastructure.Settings;
using NursingHome.Shared.Extensions;
using System.Text.Json;

namespace NursingHome.Infrastructure.Services.Notifications;

public class FirebaseNotificationService : IFirebaseNotificationService
{
    private readonly ILogger<FirebaseNotificationService> _logger;
    private readonly FcmSettings _fcmSettings;
    private readonly IUnitOfWork _unitOfWork;

    public FirebaseNotificationService(
        ILogger<FirebaseNotificationService> logger,
        IOptions<FcmSettings> fcmSettings,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _fcmSettings = fcmSettings.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default)
    {
        var deviceIds = (await _unitOfWork.Repository<Device>()
            .FindAsync(
                expression: token => token.UserId == notification.UserId,
                cancellationToken: cancellationToken))
            .Select(_ => _.Token).ToList();

        //var messages = new MulticastMessage()
        //{
        //    Tokens = deviceIds,
        //    Data = notification.ObjectToDictionary(),
        //    Notification = new FirebaseAdmin.Messaging.Notification()
        //    {
        //        Title = notification.Title,
        //        Body = notification.Content
        //    }
        //};
        var messages = new Message
        {
            Token = "1212",
            Data = notification.Data?.ObjectToDictionary(),
            Notification = new FirebaseAdmin.Messaging.Notification()
            {
                Title = notification.Title,
                Body = notification.Content
            }
        };
        _logger.LogInformation($"[MOBILE NOTIFICATION] Data: {JsonSerializer.Serialize(messages.Data)}");
        try
        {
            //var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(messages, cancellationToken);
            //_logger.LogInformation($"[MOBILE NOTIFICATION] Success push notification: {JsonSerializer.Serialize(response)}");
            var response = await FirebaseMessaging.DefaultInstance.SendAsync(messages, cancellationToken);
            _logger.LogInformation($"[MOBILE NOTIFICATION] Success push notification: {JsonSerializer.Serialize(response)}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"[MOBILE NOTIFICATION] Error when push notification: {ex.Message}");
        }

        _logger.LogInformation($"[[MOBILE NOTIFICATION]] Handle firebase notification: {notification.Id}");
    }
}