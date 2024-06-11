using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class FeedBack : BaseAuditableEntity<int>
{
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string? Content { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
