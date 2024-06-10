using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomElder
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
}
