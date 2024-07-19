using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class NurseSchedule : BaseEntity<int>
{
    public int CareScheduleId { get; set; }
    public virtual CareSchedule CareSchedule { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
}
