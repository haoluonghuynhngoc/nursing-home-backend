using NursingHome.Application.Features.OrderDetails.Models;

namespace NursingHome.Application.Features.OrderDates.Models;
public record OrderDateGetAllResponse : OrderDateResponse
{
    public virtual OrderDetailGetMissOrderResponse OrderDetail { get; set; } = default!;
}
