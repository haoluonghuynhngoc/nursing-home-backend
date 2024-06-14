using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.NursingPackages.Queries;
public record GetAllNursingPackageQuery : PaginationRequest<NursingPackage>, IRequest<PaginatedResponse<NursingPackageResponse>>
{
    public string? Search { get; set; }

    public override Expression<Func<NursingPackage, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));

        return Expression;
    }
}
