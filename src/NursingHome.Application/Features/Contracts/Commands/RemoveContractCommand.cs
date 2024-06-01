using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record RemoveContractCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? ReasonForCanceling { get; set; }
}

