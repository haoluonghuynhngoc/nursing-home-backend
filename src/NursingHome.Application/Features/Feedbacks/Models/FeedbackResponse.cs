namespace NursingHome.Application.Features.Feedbacks.Models;
public sealed record FeedbackResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string? Content { get; set; }
    public int OrderId { get; set; }
}
