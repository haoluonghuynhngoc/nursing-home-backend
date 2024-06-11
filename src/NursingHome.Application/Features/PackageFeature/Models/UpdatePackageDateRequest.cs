namespace NursingHome.Application.Features.PackageFeature.Models;
public record UpdatePackageDateRequest
{
    public int Id { get; set; }
    public DateOnly? Date { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
