namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public ICollection<PackageCategoryPackage> ServicePackages { get; set; } = new HashSet<PackageCategoryPackage>();
}
