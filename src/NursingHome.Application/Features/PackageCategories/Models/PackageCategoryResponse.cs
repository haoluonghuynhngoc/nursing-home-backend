namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<PackageCategoryPackage> Packages { get; set; } = new HashSet<PackageCategoryPackage>();
}
