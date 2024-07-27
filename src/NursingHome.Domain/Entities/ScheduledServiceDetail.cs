using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class ScheduledServiceDetail : BaseAuditableEntity<int>
{
    [Column(TypeName = "nvarchar(24)")]
    public OrderDetailType Type { get; set; }
    public int ScheduledServiceId { get; set; }
    public virtual ScheduledService ScheduledService { get; set; } = default!;
    public int? ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public int? ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public virtual ICollection<ScheduledTime> ScheduledTimes { get; set; } = new List<ScheduledTime>();
}
