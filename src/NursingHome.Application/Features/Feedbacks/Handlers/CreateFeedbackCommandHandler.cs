using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Feedbacks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Feedbacks.Handlers;
internal class CreateFeedbackCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService
    ) : IRequestHandler<CreateFeedbackCommand, MessageResponse>
{
    private readonly IGenericRepository<FeedBack> _feedbackRepository = unitOfWork.Repository<FeedBack>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    public async Task<MessageResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        if (!await _userRepository.ExistsByAsync(x => x.Id == userId))
        {
            throw new NotFoundException(nameof(User), userId);
        }
        if (!await _orderDetailRepository.ExistsByAsync(x => x.Id == request.OrderDetailId))
        {
            throw new NotFoundException($"Order Detail Have Id {request.OrderDetailId} Is Not Found");
        }

        request.UserId = userId;
        var feedBack = request.Adapt<FeedBack>();

        await _feedbackRepository.CreateAsync(feedBack);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
