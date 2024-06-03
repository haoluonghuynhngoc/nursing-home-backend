using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class CareSchedule : BaseEntity<long>
{
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Status { get; set; }
    public string? TimeSlot { get; set; }
    public string? Notes { get; set; }
    public bool IsDone { get; set; }
    public int? RoomId { get; set; }
    public virtual Room Room { get; set; } = default!;
    public virtual ICollection<CareScheduleUser> CareScheduleUsers { get; set; } = new HashSet<CareScheduleUser>();
    [Projectable]
    [NotMapped]
    public IEnumerable<User> Users => CareScheduleUsers.Select(uc => uc.User);
    public virtual ICollection<CareScheduleTask> CareScheduleTasks { get; set; } = new HashSet<CareScheduleTask>();
}
