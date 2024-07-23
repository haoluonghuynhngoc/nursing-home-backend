using NursingHome.Application.Features.UserNurseSchedules.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NurseSchedules.Models;
public record NurseScheduleResponse : BaseEntityResponse<int>
{
    public ShiftWorkerName ShiftWorkerName { get; set; } = default!;
    // public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
    public virtual ICollection<UserNurseScheduleNotUserResponse> UserNurseSchedules { get; set; } = new HashSet<UserNurseScheduleNotUserResponse>();
}
