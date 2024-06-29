using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Feedbacks.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Feedbacks.Queries;
public sealed record GetAllFeedbackQuery : PaginationRequest<FeedBack>, IRequest<PaginatedResponse<FeedbackResponse>>
{
    public string? Search { get; set; }
    public Guid? UserId { get; set; }
    public override Expression<Func<FeedBack, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Title, $"%{Search}%"));
        }
        Expression = Expression.And(_ => !UserId.HasValue || _.UserId == UserId);
        return Expression;
    }
}
