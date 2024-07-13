using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Features.ServicePackages.Models;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record OrderDetailNotElderAndContractResponse : BaseOrderDetailResponse
{
    public BaseServicePackageResponse ServicePackage { get; set; } = default!;
    //public BaseContractNursingPackageResponse Contract { get; set; } = default!;
    public ICollection<OrderDateResponse> OrderDates { get; set; } = new List<OrderDateResponse>();
}
