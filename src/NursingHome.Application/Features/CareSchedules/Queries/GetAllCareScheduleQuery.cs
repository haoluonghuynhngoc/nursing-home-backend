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
    public int? CareMonth { get; set; }
    public int? CareYear { get; set; }
    public int? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public override Expression<Func<CareSchedule, bool>> GetExpressions()
    {
        Expression = Expression.And(cs => !CareMonth.HasValue || cs.CareMonth == CareMonth);
        Expression = Expression.And(cs => !CareYear.HasValue || cs.CareYear == CareYear);
        //Expression = Expression.And(cs => !RoomId.HasValue || cs.RoomId == RoomId);
        Expression = Expression.And(cs => !UserId.HasValue
        || cs.EmployeeSchedules.Any(_ => _.UserId == UserId));

        return Expression;
    }
}
