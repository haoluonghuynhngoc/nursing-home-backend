namespace NursingHome.Domain.Entities;
public class ElderPackage
{
    public string? NamePackage { get; set; }
    public string? Status { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
