using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Feedbacks.Models;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Orders.Models;
public record OrderResponse : BaseOrderResponse
{
    public BaseUserResponse User { get; set; } = default!;
    public BaseServicePackageResponse ServicePackage { get; set; } = default!;
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
    public BaseElderResponse Elder { get; set; } = default!;
    public FeedbackResponse FeedBack { get; set; } = default!;
    public ICollection<OrderDateResponse> OrderDates { get; set; } = new List<OrderDateResponse>();
}
