using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class MonthlyCalendarDetail : BaseAuditableEntity<int>
{
    public int MonthlyCalendarId { get; set; }
    public virtual MonthlyCalendar MonthlyCalendar { get; set; } = default!;
    public int EmployeeTypeId { get; set; }
    public virtual EmployeeType EmployeeType { get; set; } = default!;
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
}
