using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Block : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    [Projectable]
    public int UsedRooms => Rooms.Count(room => room.IsUsed);
    [Projectable]
    public int UnUsedRooms => TotalRoom - UsedRooms;
    [Projectable]
    public int TotalRoom => Rooms.Count;

    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}
