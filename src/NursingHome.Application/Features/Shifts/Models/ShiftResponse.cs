using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Shifts.Models;
public record ShiftResponse : BaseEntityResponse<int>
{
    public ShiftName Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
}
