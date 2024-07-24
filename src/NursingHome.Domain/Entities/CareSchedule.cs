using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class CareSchedule : BaseEntity<int>
{
    public int CareMonth { get; set; }
    public int CareYear { get; set; }
    public string? Notes { get; set; }
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new HashSet<EmployeeSchedule>();
}
