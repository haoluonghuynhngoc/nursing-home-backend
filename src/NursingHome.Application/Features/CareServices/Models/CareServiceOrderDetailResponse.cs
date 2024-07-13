using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.ServicePackages.Models;

namespace NursingHome.Application.Features.CareServices.Models;
public record CareServiceOrderDetailResponse : BaseOrderDetailResponse
{
    public BaseServicePackageResponse ServicePackage { get; set; } = default!;
    public ICollection<OrderDateResponse> OrderDates { get; set; } = new List<OrderDateResponse>();
}
