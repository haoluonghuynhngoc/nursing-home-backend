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
    public DateTime? PaymentDate { get; set; }
    public DateOnly DueDate { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public string? PaymentUrl { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}
