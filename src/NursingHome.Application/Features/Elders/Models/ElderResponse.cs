using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public decimal? Price { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
    public ICollection<ElderUserResponse> Users { get; set; } = new HashSet<ElderUserResponse>();
    public ICollection<ElderElderPackageRegister> ElderPackageRegisters { get; set; } = new HashSet<ElderElderPackageRegister>();
}
