using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Rooms.Commands;
public sealed record CreateRoomCommand : IRequest<MessageResponse>
{
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
    [JsonIgnore]
    public Guid BlockId { get; set; }
    [JsonIgnore]
    public Guid PackageId { get; set; }
}