namespace NursingHome.Application.Features.Shifts.Models;
public sealed record ShiftCareSchedule
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}
