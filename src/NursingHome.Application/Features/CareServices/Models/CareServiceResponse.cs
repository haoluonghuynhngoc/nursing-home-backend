using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareServices.Models;
public record CareServiceResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public ICollection<CareServiceElderResponse> Elders { get; set; } = new HashSet<CareServiceElderResponse>();
}
