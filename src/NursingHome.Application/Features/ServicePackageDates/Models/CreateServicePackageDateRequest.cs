namespace NursingHome.Application.Features.ServicePackageDates.Models;
public record CreateServicePackageDateRequest
{
    public int? RepetitionDay { get; set; }
    //public DateOnly? OccurrenceDay { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
