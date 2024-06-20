using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Order : BaseAuditableEntity<int>
{
    public double Amount { get; set; }
    public Guid? PaymentReferenceId { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public OrderStatus Status { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public TransactionMethod Method { get; set; }

    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int? ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public int? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
    public int? ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public virtual ICollection<OrderDate> OrderDates { get; set; } = new List<OrderDate>();
    public virtual FeedBack FeedBack { get; set; } = default!;
}
