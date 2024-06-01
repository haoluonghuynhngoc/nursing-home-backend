namespace NursingHome.Domain.Entities;
public class PackageServiceType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Guid? PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
