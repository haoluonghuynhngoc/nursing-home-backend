using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.OrderDates.Models;
public record OrderDateResponse : BaseEntityResponse<int>
{
    public DateOnly Date { get; set; }
    public OrderDateStatus Status { get; set; }
}
