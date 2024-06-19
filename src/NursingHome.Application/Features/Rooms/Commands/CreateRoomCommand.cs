using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateRoomCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;

    public int BlockId { get; set; }
    public int? NursingPackageId { get; set; }

}
