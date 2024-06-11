using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Feedbacks.Commands;
public sealed record CreateFeedbackCommand : IRequest<MessageResponse>
{
    public int OrderId { get; set; }
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string? Content { get; set; }

}
