using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageServicesTypes.Models;
public sealed record PackageServiceTypeCalendar
{
    public long Id { get; set; }
    public RepeatPatternType RepeatType { get; set; } = default!;
    public int? LimitedRegistrants { get; set; }
    public int? CurrentRegistrants { get; set; }
    public ResourceStatus status { get; set; } = default!;
    public DateTime? EventDate { get; set; }
    public int? DateRepeat { get; set; }
    public List<DayOfWeekEnum>? DayOfWeekList { get; set; }
}
