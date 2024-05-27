using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Blocks.Models;
public sealed record BlockRoomResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    public TypeEnum Type { get; set; }
    public RoomStatus Status { get; set; }
    public int Capacity { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Length { get; set; }
}
