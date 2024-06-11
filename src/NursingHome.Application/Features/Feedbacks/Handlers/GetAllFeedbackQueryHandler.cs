using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Feedbacks.Models;
using NursingHome.Application.Features.Feedbacks.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class GetAllFeedbackQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllFeedbackQuery, PaginatedResponse<FeedbackResponse>>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();

    public async Task<PaginatedResponse<FeedbackResponse>> Handle(GetAllFeedbackQuery request, CancellationToken cancellationToken)
    {
        var paginFeedBack = await _feedbackRepository.FindAsync<FeedbackResponse>(
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            expression: request.GetExpressions(),
            orderBy: request.GetOrder(),
            cancellationToken: cancellationToken
            );
        return await paginFeedBack.ToPaginatedResponseAsync();
    }
}
