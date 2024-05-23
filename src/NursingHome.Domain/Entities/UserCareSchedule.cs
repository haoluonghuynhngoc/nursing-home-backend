using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class UserCareSchedule
{
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public long CareScheduleId { get; set; }
    public CareSchedule CareSchedule { get; set; } = default!;
    public bool IsDone { get; set; }
    public string? Notes { get; set; }
    public string? Status { get; set; }
    public string? TimeSlot { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
