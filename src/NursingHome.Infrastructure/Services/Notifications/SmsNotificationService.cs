﻿using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;

namespace NursingHome.Infrastructure.Services.Notifications;
public class SmsNotificationService(
    ISmsSender smsSender,
    ILogger<SmsNotificationService> logger) : ISmsNotificationService
{
    public async Task NotifyAsync(NotificationRequest notification, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(notification.PhoneNumber) || string.IsNullOrWhiteSpace(notification.Data))
        {
            logger.LogError($"[SMS NOTIFICATION] PhoneNumber: '{notification.PhoneNumber}' - Otp '{notification.Data}'");
            return;
        }
        logger.LogInformation($"[SMS NOTIFICATION] start send phoneNumber {notification.PhoneNumber}");
        await smsSender.SendAsync(notification.PhoneNumber, notification.Content, cancellationToken);
    }
}
