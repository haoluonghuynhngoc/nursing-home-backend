using NursingHome.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PackageDate : BaseEntity<int>
{
    public DateOnly? Date { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public DayOfWeek? DayOfWeek { get; set; }
    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
