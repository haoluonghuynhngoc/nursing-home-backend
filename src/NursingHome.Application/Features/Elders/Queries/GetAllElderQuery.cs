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
public sealed record GetAllElderQuery : PaginationRequest<Elder>, IRequest<PaginatedResponse<ElderResponse>>
{

    public string? Search { get; set; }
    public GenderStatus? Gender { get; set; }
    public ElderStatus? Status { get; set; }
    public override Expression<Func<Elder, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression
            .And(e => !Status.HasValue || e.Status == Status);

        return Expression;
    }
}
