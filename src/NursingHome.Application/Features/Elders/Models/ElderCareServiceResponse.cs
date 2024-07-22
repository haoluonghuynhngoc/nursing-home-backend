using NursingHome.Application.Features.OrderDetails.Models;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderCareServiceResponse : BaseElderResponse
{
    public ICollection<OrderDetailNotElderAndContractResponse> OrderDetails { get; set; } = new HashSet<OrderDetailNotElderAndContractResponse>();
}
