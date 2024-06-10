using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateAutoCommand : IRequest<MessageResponse>
{
    public int TotalRoom { get; set; }
    [JsonIgnore]
    public int BlockId { get; set; }
    [JsonIgnore]
    public int PackageId { get; set; }
}
