using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.ScheduledServices.Commands;
public sealed record CreateScheduleServiceCommand : IRequest<MessageResponse>;
