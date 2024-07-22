using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class UserNurseSchedule
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int NurseScheduleId { get; set; }
    public virtual NurseSchedule NurseSchedule { get; set; } = default!;
}
