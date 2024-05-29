namespace NursingHome.Application.Features.PackageTypes.Models;
public sealed record PackageTypeResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<PackageTypePackageResponse> Packages { get; set; } = new HashSet<PackageTypePackageResponse>();
}
