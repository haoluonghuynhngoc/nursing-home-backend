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
public sealed record GetEldersQuery : PaginationRequest<Elder>, IRequest<PaginatedResponse<ElderResponse>>
{

    public string? Search { get; set; }
    public GenderStatus? Gender { get; set; }
    public override Expression<Func<Elder, bool>> GetExpressions()
    {

        Expression = Expression.And(u => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(u.Name, $"%{Search}%"));

        Expression = Expression.And(u => !Gender.HasValue || u.Gender == Gender);
        return Expression;
    }
}
