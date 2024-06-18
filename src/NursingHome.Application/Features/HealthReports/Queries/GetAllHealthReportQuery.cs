using MediatR;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.HealthReports.Queries;
public sealed record GetAllHealthReportQuery : PaginationRequest<HealthReport>, IRequest<PaginatedResponse<HealthReportResponse>>
{

    public override Expression<Func<HealthReport, bool>> GetExpressions()
    {

        return Expression;
    }
}
