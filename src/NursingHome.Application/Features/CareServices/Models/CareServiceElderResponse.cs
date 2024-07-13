using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.CareServices.Models;
public record CareServiceElderResponse : BaseElderResponse
{
    public virtual ICollection<CareServiceOrderDetailResponse> OrderDetails { get; set; } = new HashSet<CareServiceOrderDetailResponse>();
}
