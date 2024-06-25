using NursingHome.Application.Features.ServicePackageCategories.Models;

namespace NursingHome.Application.Features.PackageFeature.Models;
public record ServicePackageResponse : BaseServicePackageResponse
{
    public virtual BasePackageCategoryResponse ServicePackageCategory { get; set; } = default!;
    public virtual ICollection<ServicePackageDateResponse> ServicePackageDates { get; set; } = new HashSet<ServicePackageDateResponse>();
}
