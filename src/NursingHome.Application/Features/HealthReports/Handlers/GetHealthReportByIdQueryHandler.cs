using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Features.HealthReports.Queries;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class GetHealthReportByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetHealthReportByIdQuery, HealthReportResponse>
{
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();

    public async Task<HealthReportResponse> Handle(GetHealthReportByIdQuery request, CancellationToken cancellationToken)
    {
        var healthReport = await _healthReportRepository.FindByAsync<HealthReportResponse>(x => x.Id == request.Id, cancellationToken);

        if (healthReport == null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);
        }

        if (Guid.TryParse(healthReport.CreatedBy, out Guid createdByUserId))
        {
            if (await _userRepository
            .FindByAsync<UserResponse>(_ => _.Id == createdByUserId, cancellationToken) is not { } userResponse)
            {
                throw new NotFoundException(nameof(User), createdByUserId);
            }
            healthReport.CreatorInfo = userResponse;
        }

        return healthReport;
    }
}
