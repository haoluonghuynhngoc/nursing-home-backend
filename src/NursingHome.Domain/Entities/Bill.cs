using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Bill : BaseEntity<Guid>
{
    public double TotalAmount { get; set; }
    public int TotalQuantity { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public BillStatus? Status { get; set; }
    public double PaidAmount { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<BillDetail> BillDetails { get; set; } = new HashSet<BillDetail>();
    public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
}
