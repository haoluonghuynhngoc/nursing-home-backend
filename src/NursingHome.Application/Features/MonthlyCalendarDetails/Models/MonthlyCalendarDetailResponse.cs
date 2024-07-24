using NursingHome.Application.Features.MonthlyCalendars.Models;
using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MonthlyCalendarDetails.Models;
public record MonthlyCalendarDetailResponse : BaseEntityResponse<int>
{
    public virtual MonthlyCalendarResponse MonthlyCalendar { get; set; } = default!;
    public virtual ICollection<ShiftResponse> Shifts { get; set; } = new HashSet<ShiftResponse>();
}
