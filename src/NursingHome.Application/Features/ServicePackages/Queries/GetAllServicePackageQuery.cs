using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.ServicePackages.Queries;
public record GetAllServicePackageQuery : PaginationRequest<ServicePackage>, IRequest<PaginatedResponse<ServicePackageResponse>>
{
    public string? Search { get; set; }
    public PackageType? Type { get; set; }
    public StateType? State { get; set; }
    public int? PackageCategoryId { get; set; }
    //public Guid? UserId { get; set; }

    public override Expression<Func<ServicePackage, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));
        Expression = Expression.And(_ => !Type.HasValue || _.Type == Type);
        Expression = Expression.And(_ => !PackageCategoryId.HasValue || _.ServicePackageCategoryId == PackageCategoryId);
        if (State.HasValue)
        {
            Expression = Expression.And(_ => _.State == State);
        }
        //Expression = Expression.And(_ => !UserId.HasValue || _.Orders.Any(_ => _.UserId == UserId));
        return Expression;
    }
}
