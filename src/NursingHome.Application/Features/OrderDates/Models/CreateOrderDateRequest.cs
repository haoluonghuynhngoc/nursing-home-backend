using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDates.Models;
public record CreateOrderDateRequest
{
    public DateOnly Date { get; set; }
    [JsonIgnore]
    public OrderDateStatus Status = OrderDateStatus.InComplete;
}
