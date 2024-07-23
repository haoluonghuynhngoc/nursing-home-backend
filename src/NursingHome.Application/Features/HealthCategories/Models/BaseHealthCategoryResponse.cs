using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.HealthCategories.Models;
public record BaseHealthCategoryResponse //: BaseAuditableEntityResponse<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public StateType State { get; set; }
    public string? ImageUrl { get; set; } = default!;
    public string? Description { get; set; }
}
