namespace NursingHome.Application.Features.PackageFeature.Models;
public record CreatePackageDateRequest
{
    public DateOnly? Date { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
