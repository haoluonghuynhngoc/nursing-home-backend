namespace NursingHome.Application.Features.NurseSchedules.Models;
public record CreateNurseScheduleRequest
{
    public int ShiftId { get; set; }
    public Guid UserId { get; set; }
}
