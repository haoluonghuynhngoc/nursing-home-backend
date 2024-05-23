using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Insurance : BaseEntity<Guid>
{
    // chưa cần sài 
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Type { get; set; }
    public string? Website { get; set; }
    public string? NameConpany { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactPersonPhone { get; set; }
    public string? ContactPersonEmail { get; set; }
    public string? Notes { get; set; }

}
