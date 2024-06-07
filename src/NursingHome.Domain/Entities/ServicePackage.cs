using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class ServicePackage : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string Type { get; set; } = default!;
    public int ServicePackageCategoryId { get; set; }
    public virtual ServicePackageCategory ServicePackageCategory { get; set; } = default!;
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<ServicePackageDate> ServiceDate { get; set; } = new HashSet<ServicePackageDate>();
    public virtual ICollection<ElderServicePackage> ElderServicePackages { get; set; } = new HashSet<ElderServicePackage>();
    public virtual ICollection<ServicePackageUser> ServicePackageUsers { get; set; } = new HashSet<ServicePackageUser>();
}
