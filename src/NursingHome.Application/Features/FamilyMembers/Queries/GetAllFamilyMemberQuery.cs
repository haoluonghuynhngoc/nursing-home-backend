using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.FamilyMembers.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.FamilyMembers.Queries;
public sealed record GetAllFamilyMemberQuery : PaginationRequest<FamilyMember>,
    IRequest<PaginatedResponse<FamilyMemberResponse>>
{
    public string? Search { get; set; }
    public int? ElderId { get; set; }
    public StateType? State { get; set; }
    public override Expression<Func<FamilyMember, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression.And(_ => !ElderId.HasValue || _.ElderId == ElderId);
        Expression = Expression.And(_ => !State.HasValue || _.State == State);
        return Expression;
    }
}
