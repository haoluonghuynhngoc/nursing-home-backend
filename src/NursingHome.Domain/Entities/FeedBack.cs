using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class FeedBack : BaseEntity<long>
{
    public string? Title { get; set; }
    public string? Type { get; set; }
    public int Rating { get; set; }
    public string? Status { get; set; }
    public string? ImageFeedBack { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime ResolvedDate { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;

}
