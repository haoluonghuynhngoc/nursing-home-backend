using LinqKit;
using MediatR;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Orders.Queries;
public record GetOrdersQuery : PaginationRequest<Order>, IRequest<PaginatedResponse<OrderResponse>>
{
    public Guid? UserId { get; set; }
    public OrderStatus? Status { get; set; }
    public override Expression<Func<Order, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => !UserId.HasValue || _.UserId == UserId);
        Expression = Expression.And(_ => !Status.HasValue || _.Status == Status);

        return Expression;
    }
}
