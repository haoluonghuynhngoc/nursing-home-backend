using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record OrderDetailResponse : BaseEntityResponse<int>
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public OrderDetailType Type { get; set; }
    public OrderDetailStatus Status { get; set; }
    public string? Notes { get; set; }
    public BaseServicePackageResponse ServicePackage { get; set; } = default!;
    public BaseContractNursingPackageResponse Contract { get; set; } = default!;
    public BaseElderResponse Elder { get; set; } = default!;
    public ICollection<OrderDateResponse> OrderDates { get; set; } = new List<OrderDateResponse>();
    //public  ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();
}
