using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Room : BaseEntity<int>
{
    public string? Name { get; set; }
    public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public TypeEnum? Type { get; set; } = TypeEnum.Basic;
    [Column(TypeName = "nvarchar(24)")]
    public RoomStatus? Status { get; set; }
    public int Capacity { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Length { get; set; }
    public Guid BlockId { get; set; }
    public virtual Block Block { get; set; } = default!;
    public Guid? PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
    //public Guid? UserId { get; set; }
    //public virtual User User { get; set; } = default!;
    public virtual ICollection<Elder> Elders { get; set; } = new HashSet<Elder>();
    public virtual ICollection<CareSchedule>? CareSchedules { get; set; } = new HashSet<CareSchedule>();
}