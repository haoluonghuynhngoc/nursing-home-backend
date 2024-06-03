namespace NursingHome.Domain.Entities;
public class PackageRegisterType
{
    public int Id { get; set; }
    public string? NameRegister { get; set; }
    public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
