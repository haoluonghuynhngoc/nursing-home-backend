using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class Appointment : BaseEntity<Guid>
{
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public string? Type { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsVisited { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;

}
