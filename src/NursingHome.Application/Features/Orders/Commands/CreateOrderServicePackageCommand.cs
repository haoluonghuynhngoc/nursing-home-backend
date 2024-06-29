using MediatR;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Orders.Commands;
public record CreateOrderServicePackageCommand : IRequest<MessageResponse>
{
    //[JsonIgnore]
    //public double Amount { get; set; }
    public TransactionMethod Method { get; set; }
    public DateOnly DueDate { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    //public int ServicePackageId { get; set; }
    //public int ElderId { get; set; }
    //public ICollection<CreateOrderDateRequest> OrderDates { get; set; } = new List<CreateOrderDateRequest>();
    public virtual ICollection<CreateOrderDetailServicePackageRequest> OrderDetails { get; set; } = new List<CreateOrderDetailServicePackageRequest>();
    [JsonIgnore]
    public string returnUrl { get; set; } = string.Empty;
}
