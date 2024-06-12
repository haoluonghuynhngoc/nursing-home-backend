using NursingHome.Application.Features.PackageFeature.Models;

namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public ICollection<PackageResponse> Packages { get; set; } = new HashSet<PackageResponse>();
}
