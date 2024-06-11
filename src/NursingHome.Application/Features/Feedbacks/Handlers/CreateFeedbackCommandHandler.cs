using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Feedbacks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class CreateFeedbackCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateFeedbackCommand, MessageResponse>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<MessageResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(x => x.Id == request.OrderId)
            ?? throw new NotFoundException($"Order Have Id {request.OrderId} Is Not Found");

        var feedBack = request.Adapt<FeedBack>();
        feedBack.Order = order;

        await _feedbackRepository.CreateAsync(feedBack);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
