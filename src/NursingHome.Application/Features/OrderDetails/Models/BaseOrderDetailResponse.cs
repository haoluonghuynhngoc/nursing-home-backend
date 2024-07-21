using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record BaseOrderDetailResponse : BaseEntityResponse<int>
{
    public decimal Price { get; set; }
    public bool IsPain { get; set; }
    public int Quantity { get; set; }
    public OrderDetailType Type { get; set; }
    public OrderDetailStatus Status { get; set; }
    public string? Notes { get; set; }
}
