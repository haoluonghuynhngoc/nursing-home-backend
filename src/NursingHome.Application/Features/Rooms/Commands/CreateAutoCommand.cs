using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateAutoCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;

    public int TotalRoom { get; set; }

    public int BlockId { get; set; }

    public int? NursingPackageId { get; set; }
}
