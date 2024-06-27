using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class CareSchedule : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public virtual Room Room { get; set; } = default!;
    public virtual ICollection<NurseSchedule> NurseSchedules { get; set; } = new HashSet<NurseSchedule>();
}
