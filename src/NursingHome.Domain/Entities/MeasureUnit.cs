using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class MeasureUnit : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string UnitType { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public StateType State { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public string? Description { get; set; }
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
