namespace NursingHome.Application.Features.PackageFeature.Models;
public record CreateServicePackageDateRequest
{
    public DateOnly? Date { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
