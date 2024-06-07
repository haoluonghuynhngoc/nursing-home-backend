using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Blocks.Models;
public sealed record BlockRoom
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    public RoomType? Type { get; set; }
}
