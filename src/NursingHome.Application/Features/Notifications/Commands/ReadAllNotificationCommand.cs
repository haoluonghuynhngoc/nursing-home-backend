using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Notifications.Commands;
public sealed record ReadAllNotificationCommand : IRequest<MessageResponse>;
