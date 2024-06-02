namespace NursingHome.Application.Features.PackageServices.Models;
public sealed record PackageServiceResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }
    public PackageServiceCalendar Calendar { get; set; } = default!;
    //public ICollection<PackageServiceElder> Elders { get; set; } = new HashSet<PackageServiceElder>();
    public ICollection<PackageServicePackageServiceTypes> PackageServiceTypes { get; set; } = new HashSet<PackageServicePackageServiceTypes>();
}
