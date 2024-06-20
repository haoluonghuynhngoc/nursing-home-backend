using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageFeature.Models;
public record ServicePackageDateResponse : BaseEntityResponse<int>
{
    public DateOnly? Date { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
}
