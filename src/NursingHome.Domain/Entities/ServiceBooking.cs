using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class ServiceBooking
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public RepeatPatternType RepeatType { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public ResourceStatus status { get; set; } = default!;
    public Guid? PackageId { get; set; }
    public Package Package { get; set; } = default!;
    public virtual ICollection<Calendar> Calendars { get; set; } = new HashSet<Calendar>();
}
