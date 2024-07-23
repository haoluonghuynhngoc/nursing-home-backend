using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PotentialCustomers.Commands;
public sealed record ChangeStatePotentialCustomerCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public StateType State { get; set; }
}
