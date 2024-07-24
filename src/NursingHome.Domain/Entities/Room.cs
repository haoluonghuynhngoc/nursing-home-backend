using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Room : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int Index { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public RoomType? Type { get; set; }
    public int BlockId { get; set; }
    public virtual Block Block { get; set; } = default!;
    public int? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
    [Projectable]
    public int TotalElder => Elders.Count;
    [Projectable]
    public bool IsUsed => NursingPackageId.HasValue;
    [Projectable]
    public int TotalNurseOnDuty => NursingPackage != null ? NursingPackage.NumberOfNurses : 0;
    [Projectable]
    public int TotalBed => NursingPackage != null ? NursingPackage.Capacity : 0;
    [Projectable]
    public bool AvailableBed => TotalBed > Elders.Count;
    [Projectable]
    public int UnusedBed => TotalBed - Elders.Count;
    [Projectable]
    public int UserBed => Elders.Count;
    public virtual ICollection<Elder> Elders { get; set; } = new HashSet<Elder>();
    public virtual ICollection<CareSchedule> CareSchedules { get; set; } = new HashSet<CareSchedule>();
}