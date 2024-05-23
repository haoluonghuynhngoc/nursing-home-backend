using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class HealthReport : BaseEntity<Guid>
{
    public DateTime Date { get; set; }
    // public string? Result { get; set; }
    public string? Note { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public Guid ElderId { get; set; }
    public Elder Elder { get; set; } = default!;
    public virtual ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
}
