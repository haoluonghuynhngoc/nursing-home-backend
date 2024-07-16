using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDates.Commands;
public sealed record ChangeStatusOrderDayCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public Guid? UserId { get; set; }
    [JsonIgnore]
    public DateTime? CompletedAt { get; set; }
    public OrderDateStatus Status { get; set; }
}
