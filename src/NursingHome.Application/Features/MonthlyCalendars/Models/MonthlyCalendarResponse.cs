using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MonthlyCalendars.Models;
public record MonthlyCalendarResponse : BaseEntityResponse<int>
{
    public int DateInMonth { get; set; }
}
