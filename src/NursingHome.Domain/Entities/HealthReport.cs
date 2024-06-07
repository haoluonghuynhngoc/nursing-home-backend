using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class HealthReport : BaseEntity<Guid>
{
    public string? Notes { get; set; }
    public virtual ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
}
