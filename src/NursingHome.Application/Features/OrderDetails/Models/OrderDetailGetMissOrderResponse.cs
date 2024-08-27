using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Features.ServicePackages.Models;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record OrderDetailGetMissOrderResponse : BaseOrderDetailResponse
{
    public virtual BaseServicePackageResponse ServicePackage { get; set; } = default!;
    public virtual BaseElderResponse Elder { get; set; } = default!;
    public virtual BaseOrderResponse Order { get; set; } = default!;
}
