using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDetails.Models;
public record CreateOrderDetailServicePackageRequest
{
    public string? Notes { get; set; }
    public int ServicePackageId { get; set; }
    public int ElderId { get; set; }
    [JsonIgnore]
    public OrderDetailType Type { get; set; }
    [JsonIgnore]
    public decimal Price { get; set; }
    [JsonIgnore]
    public int Quantity = 1;
    [JsonIgnore]
    public int TotalDate => OrderDates.Count;
    public virtual ICollection<CreateOrderDateRequest> OrderDates { get; set; } = new List<CreateOrderDateRequest>();
}
