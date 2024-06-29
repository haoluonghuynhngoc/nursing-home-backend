namespace NursingHome.Application.Features.NurseSchedule.Models;
public record CreateNurseScheduleRequest
{
    public int ShiftId { get; set; }
    public Guid UserId { get; set; }
}
