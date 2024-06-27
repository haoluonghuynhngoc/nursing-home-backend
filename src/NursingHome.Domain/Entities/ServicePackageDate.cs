using NursingHome.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class ServicePackageDate : BaseEntity<int>
{
    public int? RepetitionDay { get; set; }
    public DateOnly? OccurrenceDay { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public DayOfWeek? DayOfWeek { get; set; }
    public int ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
}
