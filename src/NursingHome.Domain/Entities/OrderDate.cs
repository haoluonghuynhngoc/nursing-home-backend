using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class OrderDate : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public OrderDateStatus Status { get; set; }
    public int OrderDetailId { get; set; }
    public virtual OrderDetail OrderDetail { get; set; } = default!;
}
