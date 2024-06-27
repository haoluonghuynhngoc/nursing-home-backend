using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record CreateOrderDetailNursingPackageRequest
{
    public int ContractId { get; set; }
    public string? Notes { get; set; }
    [JsonIgnore]
    public decimal Price { get; set; }
    [JsonIgnore]
    public int Quantity = 1;
    [JsonIgnore]
    public int ElderId { get; set; }

}
