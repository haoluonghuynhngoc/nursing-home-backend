using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Shifts.Queries;
public sealed record GetAllShiftQuery : PaginationRequest<Shift>, IRequest<PaginatedResponse<ShiftResponse>>
{
    public string? Search { get; set; }
    public override Expression<Func<Shift, bool>> GetExpressions()
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
