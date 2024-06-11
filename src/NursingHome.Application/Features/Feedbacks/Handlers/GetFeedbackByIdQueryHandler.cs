using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Feedbacks.Models;
using NursingHome.Application.Features.Feedbacks.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class GetFeedbackByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFeedbackByIdQuery, FeedbackResponse>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();
    public async Task<FeedbackResponse> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        var feedBack = await _feedbackRepository.FindByAsync<FeedbackResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Feedback Have Id {request.Id} Is Not Found");
        return feedBack;
    }
}
