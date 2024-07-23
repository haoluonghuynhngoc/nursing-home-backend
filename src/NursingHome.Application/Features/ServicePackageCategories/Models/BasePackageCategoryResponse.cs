using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackageCategories.Models;
public record BasePackageCategoryResponse
{
    public int Id { get; set; }
    public StateType State { get; set; }
    public string Name { get; set; } = default!;
}
