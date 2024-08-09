using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.FamilyMembers.Models;
public record FamilyMemberResponse : BaseFamilyMembersResponse
{
    public virtual ElderRoomResponse Elder { get; set; } = default!;
}
