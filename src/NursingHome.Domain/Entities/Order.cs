using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class Order : BaseAuditableEntity<int>
{
    public decimal Amount { get; set; }
    public string Status { get; set; } = default!;
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
    public int ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public virtual ICollection<OrderDate> OrderDates { get; set; } = new List<OrderDate>();
    public virtual FeedBack FeedBack { get; set; } = default!;
}
