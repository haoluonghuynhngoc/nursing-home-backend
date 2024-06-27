using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;

namespace NursingHome.Domain.Entities;
public class OrderDate : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    public OrderDateStatus Status { get; set; }
    public int OrderDetailId { get; set; }
    public virtual OrderDetail OrderDetail { get; set; } = default!;
}
