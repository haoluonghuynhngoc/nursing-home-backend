namespace NursingHome.Application.Features.Blocks.Models;
public record BaseBlockResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int UsedRooms { get; set; }
    public int UnUsedRooms { get; set; }
    public int TotalRoom { get; set; }
}
