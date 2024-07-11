using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.NursingPackages.Models;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record BaseRoomNoElderResponse : BaseRoomResponse
{
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
    public BaseBlockResponse Block { get; set; } = default!;
}
