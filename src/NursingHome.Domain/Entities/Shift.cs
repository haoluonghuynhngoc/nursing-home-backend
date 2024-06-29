using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;

namespace NursingHome.Domain.Entities;
public class Shift : BaseEntity<int>
{
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
    public virtual ICollection<NurseSchedule> NurseSchedulers { get; set; } = new HashSet<NurseSchedule>();
}
