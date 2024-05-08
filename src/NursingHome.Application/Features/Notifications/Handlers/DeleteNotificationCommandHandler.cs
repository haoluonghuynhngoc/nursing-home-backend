using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Notifications.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Notifications.Handlers;
internal sealed class DeleteNotificationCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<DeleteNotificationCommand, MessageResponse>
{

    private readonly IGenericRepository<Notification> _notificationRepository = unitOfWork.Repository<Notification>();

    public async Task<MessageResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        var notification = await _notificationRepository
            .FindByAsync(
            _ => _.Id == request.Id &&
                 _.UserId == userId,
            cancellationToken: cancellationToken);

        if (notification == null)
        {
            throw new NotFoundException(nameof(Notification), request.Id);
        }

        await _notificationRepository.DeleteAsync(notification);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.NotificationDeletedSuccess);
    }
}
