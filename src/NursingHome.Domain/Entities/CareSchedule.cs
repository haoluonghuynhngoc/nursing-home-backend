using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class CareSchedule : BaseAuditableEntity<int>
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public virtual Room Room { get; set; } = default!;
    public virtual ICollection<NurseScheduler> NurseSchedulers { get; set; } = new HashSet<NurseScheduler>();
}
