using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderResponse : BaseElderResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public BaseMedicalRecordResponse MedicalRecord { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
    public ICollection<OrderDetailNotElderAndContractResponse> OrderDetails { get; set; } = new HashSet<OrderDetailNotElderAndContractResponse>();
    public ICollection<BaseAppointmentResponse> Appointments { get; set; } = new HashSet<BaseAppointmentResponse>();
    public ICollection<BaseContractNursingPackageResponse> Contracts { get; set; } = new HashSet<BaseContractNursingPackageResponse>();
    // public BaseContractNursingPackageResponse? ContractsInUse => Contracts.FirstOrDefault(x => x.Status == ContractStatus.Pending);
    public BaseContractNursingPackageResponse? ContractsInUse =>
        Contracts.FirstOrDefault(x => x.Status == ContractStatus.Valid) ??
        Contracts.FirstOrDefault(x => x.Status == ContractStatus.Pending) ??
        Contracts.Where(x => x.Status == ContractStatus.Expired)
                 .OrderByDescending(x => x.EndDate)
                 .FirstOrDefault();
}
