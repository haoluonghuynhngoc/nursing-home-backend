using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class EmployeeSchedule : BaseAuditableEntity<int>
{
    public int CareScheduleId { get; set; }
    public virtual CareSchedule CareSchedule { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int EmployeeTypeId { get; set; }
    public virtual EmployeeType EmployeeType { get; set; } = default!;
}
