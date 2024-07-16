using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.OrderDates.Models;
public record OrderDateResponse : BaseEntityResponse<int>
{
    //public Guid? UserId { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateOnly Date { get; set; }
    public OrderDateStatus Status { get; set; }
    public BaseUserResponse User { get; set; } = default!;
}
