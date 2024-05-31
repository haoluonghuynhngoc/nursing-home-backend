using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Elders.Commands;
public sealed record AddElderToRoomCommand : IRequest<MessageResponse>
{
    public int RoomId { get; set; }
    public Guid ElderId { get; set; }
}
