using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.MonthlyCalendarDetails.Models;
public record CreateMonthlyCalendarDetailsRequest
{
    public ShiftType ShiftNames { get; set; }
    public ICollection<int> DateInMonth { get; set; } = new List<int>();
}
