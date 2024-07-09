using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PotentialCustomer : BaseAuditableEntity<int>
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public PotentialCustomerStatus Status { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
