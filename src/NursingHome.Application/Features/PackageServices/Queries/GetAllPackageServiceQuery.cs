using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.PackageServices.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.PackageServices.Queries;
public sealed record GetAllPackageServiceQuery : PaginationRequest<Package>, IRequest<PaginatedResponse<PackageServiceResponse>>
{
    /// <summary>
    /// Search field is search for Name, Status 
    /// </summary>
    public string? Search { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public override Expression<Func<Package, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.Status, $"%{Search}%"));
        }
        return Expression;
    }
}
