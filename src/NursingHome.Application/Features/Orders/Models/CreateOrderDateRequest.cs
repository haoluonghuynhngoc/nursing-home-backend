namespace NursingHome.Application.Features.Orders.Models;
public record CreateOrderDateRequest
{
    public DateOnly Date { get; set; }
}
