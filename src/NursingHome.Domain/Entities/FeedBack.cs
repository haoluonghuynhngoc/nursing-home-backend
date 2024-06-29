using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Domain.Entities;
public class FeedBack : BaseAuditableEntity<int>
{
    public string Title { get; set; } = default!;
    public RatingStatus Ratings { get; set; }
    public string? Content { get; set; }
    public int OrderDetailId { get; set; }
    public virtual OrderDetail OrderDetail { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
