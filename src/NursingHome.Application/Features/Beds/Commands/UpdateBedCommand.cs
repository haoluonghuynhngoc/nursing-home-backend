using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Beds.Commands;
public sealed record UpdateBedCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Status { get; set; }
    public int RoomId { get; set; }
}
