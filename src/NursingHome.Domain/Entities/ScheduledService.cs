using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Domain.Entities;
public class ScheduledService : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public ScheduledServiceStatus Status { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<ScheduledServiceDetail> ScheduledServiceDetails { get; set; } = new HashSet<ScheduledServiceDetail>();
}
