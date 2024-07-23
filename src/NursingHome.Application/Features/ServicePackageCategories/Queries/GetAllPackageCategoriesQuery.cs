using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.ServicePackageCategories.Queries;
public sealed record GetAllPackageCategoriesQuery : PaginationRequest<ServicePackageCategory>, IRequest<PaginatedResponse<PackageCategoryResponse>>
{
    public string? Search { get; set; }
    public StateType? State { get; set; }
    public override Expression<Func<ServicePackageCategory, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        if (State.HasValue)
        {
            Expression = Expression.And(_ => _.State == State);
        }
        return Expression;
    }
}
