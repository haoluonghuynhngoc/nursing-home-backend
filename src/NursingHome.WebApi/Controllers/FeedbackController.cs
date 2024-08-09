using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Feedbacks.Commands;
using NursingHome.Application.Features.Feedbacks.Models;
using NursingHome.Application.Features.Feedbacks.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FeedbackController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<FeedbackResponse>>> GetAllFeedbackWithPaginAsync(
    [FromQuery] GetAllFeedbackQuery query,
    CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FeedbackResponse>> GetFeedbackByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetFeedbackByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateFeedbackAsync(
        CreateFeedbackCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateFeedbackAsync(
        int id,
        UpdateFeedbackCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteFeedbackAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteFeedbackCommand(id), cancellationToken);
    }
}
