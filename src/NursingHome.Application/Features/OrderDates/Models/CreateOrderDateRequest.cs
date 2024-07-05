using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDates.Models;
public record CreateOrderDateRequest
{
    public DateOnly Date { get; set; }

    [JsonIgnore]
    public OrderDateStatus Status => Date <= DateOnly.FromDateTime(DateTime.Now)
        ? OrderDateStatus.NotPerformed
        : OrderDateStatus.InComplete;
}
