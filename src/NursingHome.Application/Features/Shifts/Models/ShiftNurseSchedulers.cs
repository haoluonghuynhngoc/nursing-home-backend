namespace NursingHome.Application.Features.Shifts.Models;
public sealed record ShiftNurseSchedulers
{
    public long Id { get; set; }
    public ShiftCareSchedule CareSchedule { get; set; } = default!;
    public ShiftUser User { get; set; } = default!;
}
