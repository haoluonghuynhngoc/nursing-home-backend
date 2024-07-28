using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using System.Text.Json;

namespace NursingHome.Infrastructure.Services.Notifications;
public class ExpoNotificationService : IExpoNotificationService
{
    private readonly ILogger<ExpoNotificationService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ExpoNotificationService(
        ILogger<ExpoNotificationService> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default)
    {
        var deviceIds = (await _unitOfWork.Repository<Device>()
            .FindAsync(
                expression: token => token.UserId == notification.UserId,
                cancellationToken: cancellationToken))
            .Select(_ => _.Token).ToList();

        if (deviceIds == null || !deviceIds.Any())
        {
            _logger.LogWarning($"No device tokens found for user {notification.UserId}. Notification will not be sent.");
            return;
        }

        IPushApiClient _client = new PushApiClient("ehAXa94NsN6NnpSTLLZkb2vnmxZC3Y-vF0k7xDkk");
        PushTicketRequest pushTicketRequest = new PushTicketRequest()
        {
            PushTo = deviceIds,
            PushTitle = notification.Title,
            PushBody = notification.Content,
            PushData = notification.Data
        };

        _logger.LogInformation($"[Expo NOTIFICATION] Data full: {JsonSerializer.Serialize(pushTicketRequest)}");
        _logger.LogInformation($"[Expo NOTIFICATION] Data: {JsonSerializer.Serialize(pushTicketRequest.PushData)}");

        try
        {
            PushTicketResponse result = await _client.SendPushAsync(pushTicketRequest);
            _logger.LogInformation($"[Expo NOTIFICATION] Success push notification: {JsonSerializer.Serialize(result)}");
        }
        catch (ExpoCommunityNotificationServer.Exceptions.InvalidRequestException ex)
        {
            _logger.LogError(ex, "Invalid request: {Message}", ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while sending notification");
        }
    }
    //public async Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default)
    //{
    //    var deviceIds = (await _unitOfWork.Repository<Device>()
    //        .FindAsync(
    //            expression: token => token.UserId == notification.UserId,
    //            cancellationToken: cancellationToken))
    //        .Select(_ => _.Token).ToList();

    //    IPushApiClient _client = new PushApiClient("ehAXa94NsN6NnpSTLLZkb2vnmxZC3Y-vF0k7xDkk");
    //    PushTicketRequest pushTicketRequest = new PushTicketRequest()
    //    {
    //        PushTo = deviceIds,
    //        PushTitle = notification.Title,
    //        PushBody = notification.Content,
    //        PushData = notification.Data
    //    };
    //    _logger.LogInformation($"[Expo NOTIFICATION] Data full: {JsonSerializer.Serialize(pushTicketRequest)}");
    //    _logger.LogInformation($"[Expo NOTIFICATION] Data: {JsonSerializer.Serialize(pushTicketRequest.PushData)}");

    //    PushTicketResponse result = await _client.SendPushAsync(pushTicketRequest);
    //    _logger.LogInformation($"[Expo NOTIFICATION] Success push notification: {JsonSerializer.Serialize(result)}");
    //}
}
