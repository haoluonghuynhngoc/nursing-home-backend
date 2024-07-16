using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class OrderDate : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public OrderDateStatus Status { get; set; }
    public DateTime? CompletedAt { get; set; }
    public Guid? UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int OrderDetailId { get; set; }
    public virtual OrderDetail OrderDetail { get; set; } = default!;
}
