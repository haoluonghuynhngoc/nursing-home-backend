namespace NursingHome.Domain.Entities;
public class ServicePackageDate
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Guid ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
}
