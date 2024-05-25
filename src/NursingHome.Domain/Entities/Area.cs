using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Area : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public int TotalFloor { get; set; }
    public Guid FacilityId { get; set; }
    public virtual Facility Facility { get; set; } = default!;
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}
