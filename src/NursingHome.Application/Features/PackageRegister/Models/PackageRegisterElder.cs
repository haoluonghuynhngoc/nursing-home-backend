using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageRegister.Models;
public sealed record PackageRegisterElder
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public decimal? PriceRegister { get; set; }
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
}
