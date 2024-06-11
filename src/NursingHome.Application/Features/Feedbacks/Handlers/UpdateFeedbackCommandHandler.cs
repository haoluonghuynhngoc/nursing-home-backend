using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Feedbacks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class UpdateFeedbackCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateFeedbackCommand, MessageResponse>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();
    public async Task<MessageResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedBack = await _feedbackRepository.FindByAsync(
             expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Feedback Have Id {request.Id} Is Not Found");
        request.Adapt(feedBack);
        await _feedbackRepository.UpdateAsync(feedBack);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
