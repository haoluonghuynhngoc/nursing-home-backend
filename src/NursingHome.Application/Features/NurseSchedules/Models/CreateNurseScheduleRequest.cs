using NursingHome.Application.Features.UserNurseSchedules.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NurseSchedules.Models;
public record CreateNurseScheduleRequest
{
    public ShiftWorkerName ShiftWorkerName { get; set; } = default!;
    //public ICollection<CreateShiftRequest> Shifts { get; set; } = new HashSet<CreateShiftRequest>();
    public ICollection<UserNurseScheduleRequest> UserNurseSchedules { get; set; } = new HashSet<UserNurseScheduleRequest>();
}
