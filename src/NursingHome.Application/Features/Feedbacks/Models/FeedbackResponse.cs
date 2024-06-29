using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Feedbacks.Models;
public sealed record FeedbackResponse : BaseFeedbackResponse
{
    public OrderDetailResponse OrderDetail { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
}
