using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateRoomCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    [JsonIgnore]
    public Guid BlockId { get; set; }
}
