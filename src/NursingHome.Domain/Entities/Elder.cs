using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Elder : BaseEntity<Guid>
{
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public GenderStatus Gender { get; set; } = GenderStatus.Male;
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
    public int BedId { get; set; }
    public virtual Bed? Bed { get; set; }
    public virtual ICollection<NurseElder> NurseElders { get; set; } = new HashSet<NurseElder>();
    public virtual ICollection<ElderPackage> ElderPackages { get; set; } = new HashSet<ElderPackage>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Package> Packages => ElderPackages.Select(ep => ep.Package);

    public virtual ICollection<ElderUser> ElderUsers { get; set; } = new HashSet<ElderUser>();
    [Projectable]
    [NotMapped]
    public IEnumerable<User> Users => ElderUsers.Select(eu => eu.User);
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<HealthReport> HealthReports { get; set; } = new HashSet<HealthReport>();
}

