using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class MonthlyCalendar : BaseAuditableEntity<int>
{
    public int DateInMonth { get; set; }
    public virtual ICollection<MonthlyCalendarDetail> MonthlyCalendarDetails { get; set; } = new HashSet<MonthlyCalendarDetail>();
}
