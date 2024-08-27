using LinqKit;
using MediatR;
using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.OrderDates.Queries;
public record GetAllOrderDateQuery : PaginationRequest<OrderDate>, IRequest<PaginatedResponse<OrderDateGetAllResponse>>
{
    public DateOnly? Date { get; set; }
    public OrderDateStatus? Status { get; set; }
    public override Expression<Func<OrderDate, bool>> GetExpressions()
    {
        if (Status.HasValue)
        {
            Expression = Expression.And(_ => _.Status == Status);
        }
        if (Date.HasValue)
        {
            Expression = Expression.And(_ => _.Date == Date);
        }
        return Expression;
    }
}
