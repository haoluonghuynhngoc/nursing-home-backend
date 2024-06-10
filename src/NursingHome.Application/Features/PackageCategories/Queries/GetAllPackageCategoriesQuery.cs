using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.PackageCategories.Queries;
public sealed record GetAllPackageCategoriesQuery : PaginationRequest<PackageCategory>, IRequest<PaginatedResponse<PackageCategoryResponse>>
{
    public string? Search { get; set; }
    public override Expression<Func<PackageCategory, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        return Expression;
    }
}
