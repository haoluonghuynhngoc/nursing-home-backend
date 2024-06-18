using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Features.HealthReports.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class GetHealthReportByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetHealthReportByIdQuery, HealthReportResponse>
{
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();
    public async Task<HealthReportResponse> Handle(GetHealthReportByIdQuery request, CancellationToken cancellationToken)
    {
        var healthReport = await _healthReportRepository.FindByAsync<HealthReportResponse>(x => x.Id == request.Id, cancellationToken);

        if (healthReport == null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);
        }

        return healthReport;
    }
}
