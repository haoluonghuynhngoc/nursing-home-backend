using MediatR;
using NursingHome.Application.Common.Enums;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Notifications.Models;
using NursingHome.Application.Features.Notifications.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Notifications.Handlers;
internal sealed class GetNotificationsQueryHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<GetNotificationsQuery, NotificationPaginatedResponse>
{
    private readonly IGenericRepository<Notification> _notificationRepository = unitOfWork.Repository<Notification>();
    public async Task<NotificationPaginatedResponse> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        request = request with
        {
            UserId = userId,
            SortDir = SortDirection.Desc,
            SortColumn = nameof(Notification.CreatedAt)
        };

        var notifications = await _notificationRepository
            .FindAsync<NotificationResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        var countUnread = await _notificationRepository
            .CountAsync(_ => _.UserId == userId && !_.IsRead, cancellationToken);

        return new NotificationPaginatedResponse(notifications, countUnread);
    }
}
