using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Calendar
{
    public long Id { get; set; }
    public DateTime? EventDate { get; set; }
    public int? Date { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public DayOfWeekEnum? DayOfWeek { get; set; }
    public int? ServiceBookingId { get; set; }
    public ServiceBooking ServiceBooking { get; set; } = default!;
}
