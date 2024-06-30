using NursingHome.Application.Models;

namespace NursingHome.Application.Features.ServicePackageDates.Models;
public record ServicePackageDateResponse : BaseEntityResponse<int>
{
    public int? RepetitionDay { get; set; }
    //public DateOnly? OccurrenceDay { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
