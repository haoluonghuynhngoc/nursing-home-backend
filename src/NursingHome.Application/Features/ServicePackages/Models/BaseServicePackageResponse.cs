using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackages.Models;
public record BaseServicePackageResponse : BaseEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Duration { get; set; }
    public int RegistrationLimit { get; set; }

    public int TimeBetweenServices { get; set; }
    public int TotalOrder { get; set; }
    public string? ImageUrl { get; set; }
    public PackageType Type { get; set; } = default!;
    public DateOnly StartRegistrationDate { get; set; }
    public DateOnly EndRegistrationDate { get; set; }
    //public DateOnly EndDate { get; set; }
    public DateOnly? EventDate { get; set; }
    public int ServicePackageCategoryId { get; set; }
}
