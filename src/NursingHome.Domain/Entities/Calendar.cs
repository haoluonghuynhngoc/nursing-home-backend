using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Calendar
{
    public long Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public RepeatPatternType RepeatType { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public ResourceStatus status { get; set; } = default!;
    public DateTime? EventDate { get; set; }
    public int? DateRepeat { get; set; }
    public Guid? PackageId { get; set; }
    public Package Package { get; set; } = default!;
    [NotMapped]
    public List<DayOfWeekEnum>? DayOfWeekList { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string? DayOfWeek
    {
        get => DayOfWeekList != null ? string.Join(",", DayOfWeekList) : null;
        set => DayOfWeekList = value?.Split(',').Select(day => (DayOfWeekEnum)Enum.Parse(typeof(DayOfWeekEnum), day)).ToList();
    }
}
