using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Room : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int TotalBed { get; set; }
    public int Index { get; set; }
    public bool AvailableBed => TotalBed > Elders.Count;
    [Projectable]
    public int UnusedBed => TotalBed - Elders.Count;
    [Projectable]
    public int UserBed => Elders.Count;
    [Column(TypeName = "nvarchar(24)")]
    public RoomType? Type { get; set; }

    [Projectable]
    public int TotalElder => Elders.Count;
    public int BlockId { get; set; }
    public virtual Block Block { get; set; } = default!;
    public int? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;

    [Projectable]
    public bool IsUsed => NursingPackageId.HasValue;
    public virtual ICollection<Elder> Elders { get; set; } = new HashSet<Elder>();
    public virtual ICollection<CareSchedule> CareSchedules { get; set; } = new HashSet<CareSchedule>();
}