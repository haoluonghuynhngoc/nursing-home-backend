using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Package : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public PackageType Type { get; set; } = default!;
    public int PackageCategoryId { get; set; }
    public virtual PackageCategory PackageCategory { get; set; } = default!;
    public virtual ICollection<PackageDate> PackageDates { get; set; } = new HashSet<PackageDate>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
