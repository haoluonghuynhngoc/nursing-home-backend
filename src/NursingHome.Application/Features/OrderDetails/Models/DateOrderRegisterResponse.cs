namespace NursingHome.Application.Features.OrderDetails.Models;
public record DateOrderRegisterResponse
{
    public int? DayOfMonth { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateOnly? Date { get; set; }
}
