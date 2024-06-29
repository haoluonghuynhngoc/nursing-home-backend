using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Image : BaseEntity<int>
{
    public string ImageUrl { get; set; } = default!;
    public int ContractId { get; set; }
    public virtual Contract Elder { get; set; } = default!;
}
