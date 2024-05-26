using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Beds.Commands;
public sealed record CreateBedCommand : IRequest<MessageResponse>
{
    public string? Status { get; set; }
    [JsonIgnore]
    public int RoomId { get; set; }
}