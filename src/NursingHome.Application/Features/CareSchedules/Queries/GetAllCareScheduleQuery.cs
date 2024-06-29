using LinqKit;
using MediatR;
using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.CareSchedules.Queries;
public sealed record GetAllCareScheduleQuery : PaginationRequest<CareSchedule>
    , IRequest<PaginatedResponse<CareScheduleResponse>>
{
    public DateOnly? Date { get; set; }
    public int? RoomId { get; set; }
    public override Expression<Func<CareSchedule, bool>> GetExpressions()
    {
        Expression = Expression.And(cs => !Date.HasValue || cs.Date == Date);
        Expression = Expression.And(cs => !RoomId.HasValue || cs.RoomId == RoomId);
        return Expression;
    }
}
