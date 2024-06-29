using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Shifts.Commands;
public sealed record UpdateShiftCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
}
