using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Commands;
public record PaymentOrderCommand : IRequest<MessageOrderResponse>
{
    public int OrderId { get; set; }
    public string returnUrl { get; set; } = string.Empty;
    public TransactionMethod Method { get; set; }

}
