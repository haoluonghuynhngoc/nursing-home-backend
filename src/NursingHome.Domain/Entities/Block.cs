using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Block : BaseEntity<Guid>
{
    public string? Name { get; set; }
    [Projectable]
    public int UsedRooms => Rooms.Count;
    [Projectable]
    public int UnUsedRooms => TotalRoom - UsedRooms;
    public int TotalRoom { get; set; }
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}
