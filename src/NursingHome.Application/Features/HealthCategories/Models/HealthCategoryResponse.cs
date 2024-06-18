namespace NursingHome.Application.Features.HealthCategories.Models;
public record HealthCategoryResponse : BaseHealthCategoryResponse
{
    public ICollection<MeasureUnitResponse> MeasureUnits { get; set; } = new HashSet<MeasureUnitResponse>();
}
