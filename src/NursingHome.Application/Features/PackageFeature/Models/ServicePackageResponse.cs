using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageFeature.Models;
public record ServicePackageResponse : BaseEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    public PackageType Type { get; set; } = default!;
    //public int ServicePackageCategoryId { get; set; }
    public virtual BasePackageCategoryResponse ServicePackageCategory { get; set; } = default!;
    public virtual ICollection<ServicePackageDateResponse> ServicePackageDates { get; set; } = new HashSet<ServicePackageDateResponse>();
}
