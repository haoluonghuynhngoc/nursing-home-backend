using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class HealthReport : BaseAuditableEntity<int>
{
    public string? Notes { get; set; }
    public virtual ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
    public int ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
}
