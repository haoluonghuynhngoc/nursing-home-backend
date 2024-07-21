using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class OrderDetail : BaseEntity<int>
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public OrderDetailType Type { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public OrderDetailStatus Status { get; set; }
    public string? Notes { get; set; }
    public int? ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public int? ContractId { get; set; }
    public virtual Contract Contract { get; set; } = default!;
    public int? ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    [Projectable]
    public bool IsPain => Order.Status == OrderStatus.Paid;
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
    public virtual ICollection<OrderDate> OrderDates { get; set; } = new List<OrderDate>();
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();
}
