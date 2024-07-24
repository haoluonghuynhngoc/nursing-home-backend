using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Shift : BaseEntity<int>
{
    [Column(TypeName = "nvarchar(24)")]
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
    public virtual ICollection<MonthlyCalendarDetail> NurseSchedulers { get; set; } = new HashSet<MonthlyCalendarDetail>();
}
