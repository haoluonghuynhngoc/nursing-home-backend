namespace NursingHome.Domain.Entities;
public class ElderNursingPackage
{
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
}
