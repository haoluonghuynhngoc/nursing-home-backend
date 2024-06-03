using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageRegister.Models;
public sealed record PackageRegisterResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public int NumberBed { get; set; }
    public bool IsRegister { get; set; }
    public int LimitedRegistration { get; set; }
    public int CurrentRegistrants { get; set; }
    public PackageStatusEnum Status { get; set; }
    public string? Promotion { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    public ICollection<PackageRegisterElder> Elders { get; set; } = new HashSet<PackageRegisterElder>();
    public PackageRegisterPackageRegisterType PackageRegisterType { get; set; } = default!;
    public ICollection<PackageRegisterRoom> Rooms { get; set; } = new HashSet<PackageRegisterRoom>();
}
