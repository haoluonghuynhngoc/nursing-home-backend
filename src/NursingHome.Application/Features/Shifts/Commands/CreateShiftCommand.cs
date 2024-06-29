using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Shifts.Commands;
public sealed record CreateShiftCommand : IRequest<MessageResponse>
{
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
}
