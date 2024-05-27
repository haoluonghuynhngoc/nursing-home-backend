using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateAutoCommand : IRequest<MessageResponse>
{
    public int TotalRoom { get; set; }
    [JsonIgnore]
    public TypeEnum Type { get; init; }
    [JsonIgnore]
    public Guid BlockId { get; set; }
    [JsonIgnore]
    public Guid PackageId { get; set; }
}
