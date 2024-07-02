using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.OrderDates.Commands;
public sealed record ChangeStatusOrderDayCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public OrderDateStatus Status { get; set; }
}
