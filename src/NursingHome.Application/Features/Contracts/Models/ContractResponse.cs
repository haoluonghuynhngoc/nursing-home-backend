using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Contracts.Models;
public sealed record ContractResponse : BaseContractResponse
{
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
    public BaseElderResponse Elder { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
}
