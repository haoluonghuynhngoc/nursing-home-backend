namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public bool AvailableBed { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Length { get; set; }
    //public Guid BlockId { get; set; }
    //public virtual Block Block { get; set; } = default!;
    //public Guid PackageId { get; set; }
    //public virtual Package Package { get; set; } = default!;
    //public Guid UserId { get; set; }
    //public virtual User User { get; set; } = default!;
    //public virtual ICollection<Bed> Beds { get; set; } = new HashSet<Bed>();
    //public virtual ICollection<CareSchedule> CareSchedules { get; set; } = new HashSet<CareSchedule>();
}