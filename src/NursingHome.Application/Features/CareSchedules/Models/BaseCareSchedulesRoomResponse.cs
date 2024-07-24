using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record BaseCareSchedulesRoomResponse : BaseEntityResponse<int>
{
    public ICollection<RoomResponse> Rooms { get; set; } = new HashSet<RoomResponse>();
    //public RoomResponse Room { get; set; } = default!;
}
