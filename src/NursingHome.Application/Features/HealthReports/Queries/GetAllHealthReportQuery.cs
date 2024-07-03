using LinqKit;
using MediatR;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.HealthReports.Queries;
public sealed record GetAllHealthReportQuery : PaginationRequest<HealthReport>, IRequest<PaginatedResponse<HealthReportResponse>>
{
    public int? ElderId { get; set; }
    /// <summary>
    /// Định dạng là yyyy-MM-dd ví dụ 2024-07-04
    /// </summary>
    public DateOnly? Date { get; set; }
    public override Expression<Func<HealthReport, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => !ElderId.HasValue || _.ElderId == ElderId);
        Expression = Expression.And(_ => !Date.HasValue || _.Date == Date);
        //Expression = Expression.And(_ => !Date.HasValue || !_.CreatedAt.HasValue || DateOnly.FromDateTime(_.CreatedAt.Value.DateTime) == Date);
        return Expression;
    }
}
