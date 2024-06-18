using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class HealthReportDetailMeasure : BaseEntity<int>
{
    public float Value { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public HealthReportDetailMeasureStatus Status { get; set; }
    public string? Note { get; set; }
    public int MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; set; } = default!;
    public int HealthReportDetailId { get; set; }
    public virtual HealthReportDetail HealthReportDetail { get; set; } = default!;
}
