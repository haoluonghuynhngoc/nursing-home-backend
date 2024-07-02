using NursingHome.Application.Features.MeasureUnits.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.HealthCategories.Models;
public record HealthCategoryResponse : BaseHealthCategoryResponse
{
    [JsonIgnore]
    public ICollection<MeasureUnitResponse> MeasureUnits { get; set; } = new HashSet<MeasureUnitResponse>();
    public ICollection<MeasureUnitResponse> MeasureUnitsActive => MeasureUnits.Where(x => x.State == StateType.Active).ToHashSet();
    //public ICollection<MeasureUnitResponse> MeasureUnitsActive => MeasureUnits.Where(x => x.State == StateType.Active).ToList();
}
