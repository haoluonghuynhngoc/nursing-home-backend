using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Features.ServicePackageDates.Models;

namespace NursingHome.Application.Features.ServicePackages.Models;
public record ServicePackageResponse : BaseServicePackageResponse
{
    public virtual BasePackageCategoryResponse ServicePackageCategory { get; set; } = default!;
    public virtual ICollection<ServicePackageDateResponse> ServicePackageDates { get; set; } = new HashSet<ServicePackageDateResponse>();
}
