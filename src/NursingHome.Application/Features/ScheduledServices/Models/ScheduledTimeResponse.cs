using NursingHome.Application.Models;

namespace NursingHome.Application.Features.ScheduledServices.Models;
public record ScheduledTimeResponse : BaseEntityResponse<int>
{
    public DateOnly Date { get; set; }
}
