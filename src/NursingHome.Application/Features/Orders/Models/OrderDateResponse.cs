using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Orders.Models;
public record OrderDateResponse : BaseEntityResponse<int>
{
    public DateOnly Date { get; set; }
}
