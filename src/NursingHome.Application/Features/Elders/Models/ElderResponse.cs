using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderResponse : BaseElderResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public BaseMedicalRecordResponse MedicalRecord { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
    public ICollection<BaseContractResponse> Contracts { get; set; } = new HashSet<BaseContractResponse>();
    public BaseContractResponse? ContractsInUse => Contracts.FirstOrDefault(x => x.Status == ContractStatus.Pending);
}
