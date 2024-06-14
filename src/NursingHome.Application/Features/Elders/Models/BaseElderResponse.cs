using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public record BaseElderResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Notes { get; set; }
    //public int RoomId { get; set; }
    public Guid UserId { get; set; }
}
