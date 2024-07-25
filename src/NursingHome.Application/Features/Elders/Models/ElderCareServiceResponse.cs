using NursingHome.Application.Features.OrderDetails.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderCareServiceResponse : BaseElderResponse
{
    [JsonIgnore]
    public ICollection<OrderDetailNotElderAndContractResponse> OrderDetails { get; set; } = new HashSet<OrderDetailNotElderAndContractResponse>();
    public ICollection<OrderDetailNotElderAndContractResponse> OrderDetailsService => OrderDetails.Where(_ => _.ServicePackage != null).ToList();
}
