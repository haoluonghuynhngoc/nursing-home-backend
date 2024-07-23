using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.ServicePackages.Commands;
public sealed record ChangeStateServicePackageCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public StateType State { get; set; }
}

