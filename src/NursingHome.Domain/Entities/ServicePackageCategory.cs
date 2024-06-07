namespace NursingHome.Domain.Entities;
public class ServicePackageCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public virtual ICollection<ServicePackage> ServicePackages { get; set; } = new HashSet<ServicePackage>();
}
