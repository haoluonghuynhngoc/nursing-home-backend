using LinqKit;
using MediatR;
using NursingHome.Application.Features.EmployeeSchedules.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.EmployeeSchedules.Queries;
public sealed record GetAllEmployeeScheduleQuery
    : PaginationRequest<EmployeeSchedule>, IRequest<PaginatedResponse<EmployeeSchedulesResponse>>
{
    public int? CareMonth { get; set; }
    public int? CareYear { get; set; }
    public int? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public override Expression<Func<EmployeeSchedule, bool>> GetExpressions()
    {
        Expression = Expression.And(es => !CareMonth.HasValue || es.CareSchedule.CareMonth == CareMonth);
        Expression = Expression.And(es => !CareYear.HasValue || es.CareSchedule.CareYear == CareYear);
        //  Expression = Expression.And(es => !RoomId.HasValue || es.CareSchedule.RoomId == RoomId);
        Expression = Expression.And(es => !UserId.HasValue || es.UserId == UserId);
        return Expression;
    }
}