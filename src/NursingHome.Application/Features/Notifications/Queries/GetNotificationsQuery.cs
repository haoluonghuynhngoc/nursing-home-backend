using LinqKit;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Notifications.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Notifications.Queries;
public sealed record GetNotificationsQuery : PaginationRequest<Notification>, IRequest<NotificationPaginatedResponse>
{
    /// <summary>
    /// Search field is search for title or content
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Format for From is "yyyy-MM-dd" or "MM/dd/yyyy"
    /// </summary>
    /// <example>2021-02-25T00:00:00.000000+00:00</example>
    public DateTimeOffset? From { get; set; }

    /// <summary>
    /// Format for To is "yyyy-MM-dd" or "MM/dd/yyyy"
    /// </summary>
    /// <example>2029-03-25T00:00:00.000000+00:00</example>
    public DateTimeOffset? To { get; set; }
    public bool? IsRead { get; set; }

    [BindNever]
    public Guid UserId { get; set; }

    public override Expression<Func<Notification, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression.And(notification => EF.Functions.Like(notification.Content, $"%{Search}%"));
            Expression = Expression.Or(notification => EF.Functions.Like(notification.Title, $"%{Search}%"));
        }

        Expression = Expression.And(notification => !From.HasValue || notification.CreatedAt >= From);
        Expression = Expression.And(notification => !To.HasValue || notification.CreatedAt <= To);
        Expression = Expression.And(notification => !IsRead.HasValue || notification.IsRead == IsRead);
        Expression = Expression.And(notification => notification.UserId == UserId);

        return Expression;
    }
}
