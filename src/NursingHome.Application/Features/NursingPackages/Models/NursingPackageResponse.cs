using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.NursingPackages.Models;
public record NursingPackageResponse : BaseNursingPackageResponse
{
    //public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public ICollection<BaseRoomResponse> Rooms { get; set; } = new HashSet<BaseRoomResponse>();
}
