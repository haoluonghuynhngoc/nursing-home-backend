namespace NursingHome.Application.Features.Blocks.Models;
public sealed record BlockResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public int TotalFloor { get; set; }
    public int TotalRoom => Rooms?.Count ?? 0;
    public ICollection<BlockRoomResponse> Rooms { get; set; } = new HashSet<BlockRoomResponse>();
}
