namespace NursingHome.Application.Models;
public sealed record MessageOrderResponse
{
    public int OrderId { get; set; }
    public string Message { get; set; } = default!;
}
