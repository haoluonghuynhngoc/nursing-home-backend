using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Orders.Commands;
public record ChangeMethodPaymentOrderCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public TransactionMethod Method { get; set; }
    //public OrderStatus Status { get; set; }
}
