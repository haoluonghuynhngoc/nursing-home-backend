using NursingHome.Application.Features.NursingPackages.Models;

namespace NursingHome.Application.Features.Contracts.Models;
public sealed record BaseContractNursingPackageResponse : BaseContractResponse
{
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
}
