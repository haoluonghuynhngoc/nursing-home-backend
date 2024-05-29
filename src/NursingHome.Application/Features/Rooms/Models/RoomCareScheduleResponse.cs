namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomCareScheduleResponse
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Status { get; set; }
    public string? TimeSlot { get; set; }
    public string? Notes { get; set; }
    public bool IsDone { get; set; }
}
