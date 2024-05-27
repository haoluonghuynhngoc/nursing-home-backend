using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record UpdateRoomCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    public TypeEnum Type { get; set; } = TypeEnum.Basic;
    public RoomStatus Status { get; set; } = RoomStatus.Available;
    public int Capacity { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Length { get; set; }
    public Guid BlockId { get; set; }
}