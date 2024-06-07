namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomBlock
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int UsedRooms { get; set; }
    public int UnUsedRooms { get; set; }
    public int TotalRoom { get; set; }
}
