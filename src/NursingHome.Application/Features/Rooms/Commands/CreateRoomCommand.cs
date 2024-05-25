using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateRoomCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public bool AvailableBed { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Length { get; set; }
    public Guid BlockId { get; set; }
}