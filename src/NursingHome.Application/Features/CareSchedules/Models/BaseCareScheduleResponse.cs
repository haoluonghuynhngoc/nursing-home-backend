using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record BaseCareScheduleResponse : BaseEntityResponse<int>
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }

}
