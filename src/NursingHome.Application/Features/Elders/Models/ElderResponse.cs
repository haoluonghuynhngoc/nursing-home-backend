using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderResponse
{
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
    public ElderBedResponse? Bed { get; set; }
    //public virtual ICollection<ElderPackage> ElderPackages { get; set; } = new HashSet<ElderPackage>();
    //[Projectable]
    //[NotMapped]
    //public IEnumerable<Package> Packages => ElderPackages.Select(ep => ep.Package);

    //public virtual ICollection<ElderUser> ElderUsers { get; set; } = new HashSet<ElderUser>();
    //[Projectable]
    //[NotMapped]
    //public IEnumerable<User> Users => ElderUsers.Select(eu => eu.User);
    //public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    //public virtual ICollection<HealthReport> HealthReports { get; set; } = new HashSet<HealthReport>();
}
