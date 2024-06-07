using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Room : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public RoomType? Type { get; set; } = RoomType.VacantRoom;
    public Guid BlockId { get; set; }
    public virtual Block Block { get; set; } = default!;
    public virtual ICollection<Elder> Elders { get; set; } = new HashSet<Elder>();
}