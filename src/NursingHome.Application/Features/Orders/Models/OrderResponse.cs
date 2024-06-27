using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Orders.Models;
public record OrderResponse : BaseOrderResponse
{
    public BaseUserResponse User { get; set; } = default!;
    public ICollection<OrderDetailResponse> OrderDetails { get; set; } = new List<OrderDetailResponse>();
}
