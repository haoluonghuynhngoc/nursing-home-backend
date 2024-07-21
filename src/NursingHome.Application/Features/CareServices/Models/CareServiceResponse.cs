using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareServices.Models;
public record CareServiceResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public ICollection<ElderCareServiceResponse> Elders { get; set; } = new HashSet<ElderCareServiceResponse>();
}
