using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Features.HealthReports.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class GetAllHealthReportQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllHealthReportQuery, PaginatedResponse<HealthReportResponse>>
{
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();

    public async Task<PaginatedResponse<HealthReportResponse>> Handle(GetAllHealthReportQuery request, CancellationToken cancellationToken)
    {
        var healthReport = await _healthReportRepository
             .FindAsync<HealthReportResponse>(
                 request.PageIndex,
                 request.PageSize,
                 request.GetExpressions(),
                 request.GetOrder(),
                 cancellationToken);

        return await healthReport.ToPaginatedResponseAsync();
    }
}
