using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class ScheduledServiceDetail : BaseAuditableEntity<int>
{
    public int ScheduledServiceId { get; set; }
    public virtual ScheduledService ScheduledService { get; set; } = default!;
    public int? ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public int? ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public virtual ICollection<ScheduledTime> ScheduledTimes { get; set; } = new List<ScheduledTime>();
}
