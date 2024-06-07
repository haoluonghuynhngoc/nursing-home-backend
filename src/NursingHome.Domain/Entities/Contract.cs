using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class Contract : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Content { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string? Notes { get; set; }
    public string Status { get; set; } = default!;
    public string? Description { get; set; }
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
