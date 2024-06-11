using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Feedbacks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class DeleteFeedbackCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteFeedbackCommand, MessageResponse>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();
    public async Task<MessageResponse> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.FindByAsync
            (x => x.Id == request.Id, cancellationToken: cancellationToken)
            ?? throw new NotFoundException($"Feedback Have Id {request.Id} Is Not Found");

        await _feedbackRepository.DeleteAsync(feedback);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
