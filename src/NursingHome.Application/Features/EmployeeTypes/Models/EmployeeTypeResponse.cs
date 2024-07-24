using NursingHome.Application.Features.MonthlyCalendarDetails.Models;

namespace NursingHome.Application.Features.EmployeeTypes.Models;
public record EmployeeTypeResponse : BaseEmployeeTypeResponse
{
    public ICollection<MonthlyCalendarDetailResponse> MonthlyCalendarDetails { get; set; } = new HashSet<MonthlyCalendarDetailResponse>();
}
