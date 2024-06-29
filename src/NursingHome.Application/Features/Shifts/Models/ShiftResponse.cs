using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Shifts.Models;
public sealed record ShiftResponse
{
    public int Id { get; set; }
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;

}
