using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageServices.Models;
public sealed record PackageServiceServiceBooking
{
    public int Id { get; set; }
    public RepeatPatternType RepeatType { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public ResourceStatus status { get; set; } = default!;
    public ICollection<PackageServiceCalendar> Calendars { get; set; } = new HashSet<PackageServiceCalendar>();
    public ICollection<PackageServiceElder> Elders { get; set; } = new HashSet<PackageServiceElder>();
}
