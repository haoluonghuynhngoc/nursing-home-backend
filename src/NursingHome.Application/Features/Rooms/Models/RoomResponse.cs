using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.NursingPackages.Models;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomResponse : BaseRoomResponse
{
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
    public BaseBlockResponse Block { get; set; } = default!;
    public ICollection<BaseElderResponse> Elders { get; set; } = new HashSet<BaseElderResponse>();
}
