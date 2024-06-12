using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public PackageCategoryType Type { get; set; }
}
