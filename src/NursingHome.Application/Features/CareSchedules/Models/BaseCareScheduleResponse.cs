using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record BaseCareScheduleResponse : BaseEntityResponse<int>
{
    public int CareMonth { get; set; }
    public int CareYear { get; set; }
    public string? Notes { get; set; }
    //public int RoomId { get; set; }

}
