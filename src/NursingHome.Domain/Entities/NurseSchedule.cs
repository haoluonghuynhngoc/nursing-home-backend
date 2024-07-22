using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class NurseSchedule : BaseEntity<int>
{
    [Column(TypeName = "nvarchar(24)")]
    public ShiftWorkerName ShiftWorkerName { get; set; } = default!;
    public int CareScheduleId { get; set; }
    public virtual CareSchedule CareSchedule { get; set; } = default!;
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
    public virtual ICollection<UserNurseSchedule> UserNurseSchedules { get; set; } = new HashSet<UserNurseSchedule>();
}
