using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class FeedBack : BaseAuditableEntity<int>
{
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string? Content { get; set; }
    public int OrderDetailId { get; set; }
    public virtual OrderDetail OrderDetail { get; set; } = default!;
}
