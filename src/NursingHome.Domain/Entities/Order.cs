using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class Order : BaseEntity<Guid>
{
    public decimal Amount { get; set; }
    public string Status { get; set; } = default!;
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public virtual FeedBack FeedBack { get; set; } = default!;
    public Guid? ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public Guid? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<OrderDate> OrderDates { get; set; } = new List<OrderDate>();
}
