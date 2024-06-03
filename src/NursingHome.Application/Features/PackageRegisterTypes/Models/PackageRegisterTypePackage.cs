using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageRegisterTypes.Models;
public sealed record PackageRegisterTypePackage
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public int LimitedRegistration { get; set; }
    public int CurrentRegistrants { get; set; }
    public PackageStatusEnum Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }
}
