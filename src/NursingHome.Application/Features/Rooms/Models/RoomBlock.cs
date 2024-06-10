namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomBlock
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int TotalRoom { get; set; }
}
