using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ScheduledServices.Models;
public record ScheduledServiceResponse : BaseEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public ScheduledServiceStatus Status { get; set; }
    public BaseUserResponse User { get; set; } = default!;
    public virtual ICollection<ScheduledServiceDetailResponse> ScheduledServiceDetails { get; set; } = new HashSet<ScheduledServiceDetailResponse>();
}
