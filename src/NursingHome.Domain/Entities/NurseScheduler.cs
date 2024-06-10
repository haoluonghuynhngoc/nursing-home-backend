using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class NurseScheduler
{
    public int Id { get; set; }
    public int CareScheduleId { get; set; }
    public virtual CareSchedule CareSchedule { get; set; } = default!;
    public int ShiftId { get; set; }
    public virtual Shift Shift { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
