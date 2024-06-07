using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class FeedBack : BaseEntity<Guid>
{
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string Content { get; set; } = default!;
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
