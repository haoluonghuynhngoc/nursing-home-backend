namespace NursingHome.Domain.Entities;
public class ElderPackage
{
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
