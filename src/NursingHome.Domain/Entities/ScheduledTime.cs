using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class ScheduledTime : BaseAuditableEntity<int>
{
    public DateOnly Date { get; set; }
    public int ScheduledServiceDetailId { get; set; }
    public virtual ScheduledServiceDetail ScheduledServiceDetail { get; set; } = default!;
}
