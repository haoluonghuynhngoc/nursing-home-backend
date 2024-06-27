using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class ServicePackage : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Duration { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    [Projectable]
    public int TotalOrder => OrderDetails.Count;
    public string? ImageUrl { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public PackageType Type { get; set; } = default!;

    public DateOnly EndDate { get; set; }

    public int ServicePackageCategoryId { get; set; }
    public virtual ServicePackageCategory ServicePackageCategory { get; set; } = default!;
    public virtual ICollection<ServicePackageDate> ServicePackageDates { get; set; } = new HashSet<ServicePackageDate>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
}
