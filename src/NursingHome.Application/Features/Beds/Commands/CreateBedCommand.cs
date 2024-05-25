using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Beds.Commands;
public sealed record CreateBedCommand : IRequest<MessageResponse>
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public int RoomId { get; set; }
}