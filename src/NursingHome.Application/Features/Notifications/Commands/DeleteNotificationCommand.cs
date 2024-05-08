using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Notifications.Commands;
public sealed record DeleteNotificationCommand(int Id) : IRequest<MessageResponse>;

