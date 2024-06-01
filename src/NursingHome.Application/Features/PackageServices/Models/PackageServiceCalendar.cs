using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageServices.Models;
public sealed record PackageServiceCalendar
{
    public long Id { get; set; }
    public DateTime? EventDate { get; set; }
    public int? Date { get; set; }
    public DayOfWeekEnum? DayOfWeek { get; set; }

}
