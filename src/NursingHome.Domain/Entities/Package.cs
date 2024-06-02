using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Package : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Content { get; set; }
    public int NumberBed { get; set; }
    public string? Currency { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int DurationTime { get; set; }
    public int DurationMonth { get; set; }
    public int PackageCategoryId { get; set; }
    public PackageCategory PackageCategory { get; set; } = default!;
    public int? PackageRegisterTypeId { get; set; }
    public PackageRegisterType PackageRegisterType { get; set; } = default!;
    public Calendar Calendar { get; set; } = default!;
    public virtual ICollection<PackageUser> PackageUsers { get; set; } = new HashSet<PackageUser>();
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();
    public virtual ICollection<PackageServiceType> PackageServiceTypes { get; set; } = new HashSet<PackageServiceType>();
    public virtual ICollection<ElderPackage> ElderPackages { get; set; } = new HashSet<ElderPackage>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Elder> Elders => ElderPackages.Select(ep => ep.Elder);
}
