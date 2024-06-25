using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Models;
public record BaseOrderResponse : BaseAuditableEntityResponse<int>
{
    public double Amount { get; set; }
    public OrderStatus Status { get; set; }
    public TransactionMethod Method { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public int TotalOrder { get; set; }
    public Guid UserId { get; set; }
    public int? ServicePackageId { get; set; }
    public int? NursingPackageId { get; set; }
    public int? ElderId { get; set; }
}
