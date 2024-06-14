using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderResponse : BaseElderResponse
{
    public MedicalRecordResponse MedicalRecord { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
}
