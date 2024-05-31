namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderElderPackageRegister
{
    public long Id { get; set; }
    public string? NamePackage { get; set; }
    public string? Status { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ElderPackageRegisterResponse Package { get; set; } = default!;
}
