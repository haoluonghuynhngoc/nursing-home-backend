using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Models;
public record BaseOrderResponse : BaseAuditableEntityResponse<int>
{
    public double Amount { get; set; }
    public DateOnly DueDate { get; set; }
    public Guid? PaymentReferenceId { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime PaymentDate { get; set; }
    public TransactionMethod Method { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }

}
