using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Elders.Queries;
public sealed record GetElderWithPaginationQuery : PaginationRequest<Elder>, IRequest<PaginatedResponse<ElderResponse>>
{
    /// <summary>
    /// Search field is search for fullName or IdentityNumber or Nationality 
    /// </summary>
    public string? Search { get; set; }
    public string? Status { get; set; }
    public GenderStatus? Gender { get; set; }
    public DateTime? InDate { get; set; }
    public DateTime? OutDate { get; set; }
    public override Expression<Func<Elder, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.FullName, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.IdentityNumber, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.Nationality, $"%{Search}%"));
        }
        return Expression;
    }
}
