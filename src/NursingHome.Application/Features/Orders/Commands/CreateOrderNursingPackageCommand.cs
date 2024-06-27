using MediatR;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Orders.Commands;
public record CreateOrderNursingPackageCommand : IRequest<MessageResponse>
{
    //public double Amount { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual ICollection<CreateOrderDetailNursingPackageRequest> OrderDetails { get; set; } = new List<CreateOrderDetailNursingPackageRequest>();
    //public int NursingPackageId { get; set; }
}
