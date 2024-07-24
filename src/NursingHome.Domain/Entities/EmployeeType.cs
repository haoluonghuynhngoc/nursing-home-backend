using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class EmployeeType : BaseAuditableEntity<int>
{
    [Column(TypeName = "nvarchar(24)")]
    public EmployeeTypeName Name { get; set; }
    public virtual ICollection<MonthlyCalendarDetail> MonthlyCalendarDetails { get; set; } = new HashSet<MonthlyCalendarDetail>();
    public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new HashSet<EmployeeSchedule>();
}
