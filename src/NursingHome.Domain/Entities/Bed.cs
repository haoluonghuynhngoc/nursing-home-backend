namespace NursingHome.Domain.Entities;
public class Bed
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; } = default!;
    //public Guid ElderId { get; set; }
    public Elder? Elder { get; set; }
}