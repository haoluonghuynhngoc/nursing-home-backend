using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class NursingPackage : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string ImageUrl { get; set; } = default!;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<NursingPackageUser> NursingPackageUsers { get; set; } = new HashSet<NursingPackageUser>();
    public virtual ICollection<ElderNursingPackage> ElderNursingPackages { get; set; } = new HashSet<ElderNursingPackage>();
}
