using NursingHome.Application.Features.Images.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Models;
public record BaseContractResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public int Duration { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Content { get; set; } = default!;
    //public string? ImageUrl { get; set; }
    public ICollection<ImageResponse> Images { get; set; } = new HashSet<ImageResponse>();
    public string? Notes { get; set; }
    public string? ReasonForCanceling { get; set; }
    public ContractStatus Status { get; set; } = default!;
    public string? Description { get; set; }
}
