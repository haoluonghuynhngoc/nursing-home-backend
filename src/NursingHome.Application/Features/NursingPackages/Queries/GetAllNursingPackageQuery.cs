using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.NursingPackages.Queries;
public record GetAllNursingPackageQuery : PaginationRequest<NursingPackage>, IRequest<PaginatedResponse<NursingPackageResponse>>
{
    public string? Search { get; set; }
    public StateType? State { get; set; }
    public override Expression<Func<NursingPackage, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));
        if (State.HasValue)
        {
            Expression = Expression.And(_ => _.State == State);
        }
        return Expression;
    }
}
