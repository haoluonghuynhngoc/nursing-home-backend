namespace NursingHome.Application.Features.PackageServicesTypes.Models;
public sealed record PackageServiceTypeResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public PackageServiceTypePackage Package { get; set; } = default!;
}
