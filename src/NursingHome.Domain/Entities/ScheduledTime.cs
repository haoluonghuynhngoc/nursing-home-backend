using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class ScheduledTime : BaseAuditableEntity<int>
{
    public DateOnly Date { get; set; }
    public int ScheduledServiceId { get; set; }
    public virtual ScheduledService ScheduledService { get; set; } = default!;
}
