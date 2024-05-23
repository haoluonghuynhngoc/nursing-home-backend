namespace NursingHome.Domain.Entities;
public class PackageType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
