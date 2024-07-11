using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ScheduledServices.Models;
public record ScheduledServiceDetailResponse : BaseEntityResponse<int>
{
    public OrderDetailType Type { get; set; }
    public BaseServicePackageResponse ServicePackage { get; set; } = default!;
    public BaseElderResponse Elder { get; set; } = default!;
    public ICollection<ScheduledTimeResponse> ScheduledTimes { get; set; } = new List<ScheduledTimeResponse>();
}
