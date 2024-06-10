using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryPackage
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    public PackageType Type { get; set; } = default!;
}
