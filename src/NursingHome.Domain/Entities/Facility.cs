using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Facility : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? ImageFacility { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string? Status { get; set; }
    public ICollection<Area> Areas { get; set; } = new HashSet<Area>();
}
