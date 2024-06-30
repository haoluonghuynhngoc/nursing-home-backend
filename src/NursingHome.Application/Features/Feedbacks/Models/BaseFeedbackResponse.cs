using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Feedbacks.Models;
public record BaseFeedbackResponse : BaseAuditableEntityResponse<int>
{
    public string Title { get; set; } = default!;
    public RatingStatus Ratings { get; set; }
    public string? Content { get; set; }
    public int OrderDetailId { get; set; }
    public Guid UserId { get; set; }

}
