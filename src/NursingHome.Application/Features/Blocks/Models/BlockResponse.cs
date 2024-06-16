using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.Blocks.Models;
public record BlockResponse : BaseBlockResponse
{
    public ICollection<BaseRoomResponse> Rooms { get; set; } = new HashSet<BaseRoomResponse>();
}
