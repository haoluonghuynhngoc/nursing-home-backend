namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderBedResponse
{
    public int Id { get; set; }
    public string? Status { get; set; }
    //public int RoomId { get; set; }
    ////public bool IsDeleted { get; set; }
    //public Room? Room { get; set; } = default!;
}
