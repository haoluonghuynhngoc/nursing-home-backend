using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class OrderDate : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
