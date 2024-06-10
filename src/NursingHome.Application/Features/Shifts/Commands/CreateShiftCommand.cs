using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Shifts.Commands;
public sealed record CreateShiftCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
}
