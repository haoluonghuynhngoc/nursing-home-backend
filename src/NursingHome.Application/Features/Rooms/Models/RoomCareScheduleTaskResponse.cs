namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomCareScheduleTaskResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public bool IsDone { get; set; }
}
