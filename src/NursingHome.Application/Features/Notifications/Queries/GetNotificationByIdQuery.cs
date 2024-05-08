using MediatR;
using NursingHome.Application.Features.Notifications.Models;

namespace NursingHome.Application.Features.Notifications.Queries;
public sealed record GetNotificationByIdQuery(int Id) : IRequest<NotificationResponse>;
