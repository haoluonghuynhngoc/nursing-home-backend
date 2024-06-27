using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Notifications.Models;
using NursingHome.Application.Features.Notifications.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Notifications.Handlers;
internal sealed class GetNotificationByIdQueryHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<GetNotificationByIdQuery, NotificationResponse>
{
    private readonly IGenericRepository<Notification> _notificationRepository = unitOfWork.Repository<Notification>();

    public async Task<NotificationResponse> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        var notification = await _notificationRepository
            .FindByAsync<NotificationResponse>(
            _ => _.Id == request.Id &&
                 _.UserId == userId,
            cancellationToken);

        if (notification == null)
        {
            throw new NotFoundException(nameof(Notification), request.Id);
        }

        return notification;
    }
}
