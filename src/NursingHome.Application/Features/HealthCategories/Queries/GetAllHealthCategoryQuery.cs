using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.HealthCategories.Queries;
public sealed record GetAllHealthCategoryQuery : PaginationRequest<HealthCategory>, IRequest<PaginatedResponse<HealthCategoryResponse>>
{
    public string? Search { get; set; }

    public int[] Ints { get; set; } = Array.Empty<int>();

    public override Expression<Func<HealthCategory, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression.And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }

        Expression = Expression.And(u => !Ints.Any() || Ints.Contains(u.Id));
        return Expression;
    }
}
