using LinqKit;
using MediatR;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Orders.Queries;
public record GetOrdersQuery : PaginationRequest<Order>, IRequest<PaginatedResponse<OrderResponse>>
{
    public Guid? UserId { get; set; }
    public override Expression<Func<Order, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => !UserId.HasValue || _.UserId == UserId);

        return Expression;
    }
}
