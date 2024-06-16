namespace NursingHome.Application.Features.ServicePackageCategories.Models;
public record BasePackageCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
