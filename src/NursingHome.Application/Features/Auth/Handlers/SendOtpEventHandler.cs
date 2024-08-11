using MediatR;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Features.Auth.Events;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Auth.Handlers;
internal sealed class SendOtpEventHandler(INotifier notifier) : INotificationHandler<SendOtpEvent>
{
    public async Task Handle(SendOtpEvent notification, CancellationToken cancellationToken)
    {
        var notificationMessage = new NotificationRequest
        {
            PhoneNumber = notification.PhoneNumber,
            Data = notification.Otp,
            UserId = notification.UserId,
            //Type = NotificationType.ExpoPush
            Type = NotificationType.Otp
        };

        await notifier.NotifyAsync(notificationMessage, true, cancellationToken);
    }
}

