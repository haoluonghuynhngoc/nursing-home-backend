using NursingHome.Application.Features.PackageFeature.Models;

namespace NursingHome.Application.Features.ServicePackageCategories.Models;
public record PackageCategoryResponse : BasePackageCategoryResponse
{
    public ICollection<ServicePackageResponse> Packages { get; set; } = new HashSet<ServicePackageResponse>();
}
