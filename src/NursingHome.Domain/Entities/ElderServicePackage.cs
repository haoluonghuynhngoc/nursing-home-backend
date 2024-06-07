namespace NursingHome.Domain.Entities;
public class ElderServicePackage
{
    public Guid ElderId { get; set; }
    public Elder Elder { get; set; } = default!;
    public Guid ServicePackageId { get; set; }
    public ServicePackage ServicePackage { get; set; } = default!;

}
