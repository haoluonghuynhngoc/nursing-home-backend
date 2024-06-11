using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageFeature.Models;
public record PackageDateResponse : BaseEntityResponse<int>
{
    public DateOnly? Date { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public int PackageId { get; set; }
}
