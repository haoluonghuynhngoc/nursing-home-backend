using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Package : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public int Capacity { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }
    public int DurationMonth { get; set; }
    public int PackageTypeId { get; set; }
    public PackageType PackageType { get; set; } = default!;

    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<BillDetail> BillDetails { get; set; } = new HashSet<BillDetail>();
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();

    public virtual ICollection<ElderPackage> ElderPackages { get; set; } = new HashSet<ElderPackage>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Elder> Elders => ElderPackages.Select(ep => ep.Elder);
}
