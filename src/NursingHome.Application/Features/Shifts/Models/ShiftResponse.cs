namespace NursingHome.Application.Features.Shifts.Models;
public sealed record ShiftResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;

}
