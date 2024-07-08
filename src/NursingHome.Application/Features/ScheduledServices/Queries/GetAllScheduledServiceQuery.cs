using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.ScheduledServices.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.ScheduledServices.Queries;
public sealed record GetAllScheduledServiceQuery : PaginationRequest<ScheduledService>, IRequest<PaginatedResponse<ScheduledServiceResponse>>
{
    public string? Search { get; set; }
    public ScheduledServiceStatus? Status { get; set; }
    public override Expression<Func<ScheduledService, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression.And(_ => !Status.HasValue || _.Status == Status);
        return Expression;
    }
}
