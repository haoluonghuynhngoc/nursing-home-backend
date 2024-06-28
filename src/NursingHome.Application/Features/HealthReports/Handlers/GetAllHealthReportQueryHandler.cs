using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Features.HealthReports.Queries;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class GetAllHealthReportQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllHealthReportQuery, PaginatedResponse<HealthReportResponse>>
{
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<PaginatedResponse<HealthReportResponse>> Handle(GetAllHealthReportQuery request, CancellationToken cancellationToken)
    {
        var healthReport = await _healthReportRepository
             .FindAsync<HealthReportResponse>(
                 request.PageIndex,
                 request.PageSize,
                 request.GetExpressions(),
                 request.GetOrder(),
                 cancellationToken);

        foreach (var report in healthReport)
        {
            if (Guid.TryParse(report.CreatedBy, out Guid createdByUserId))
            {
                var userResponse = await _userRepository
                    .FindByAsync<UserResponse>(u => u.Id == createdByUserId, cancellationToken);

                if (userResponse == null)
                {
                    throw new NotFoundException(nameof(User), createdByUserId);
                }

                report.CreatorInfo = userResponse;
            }
        }

        return await healthReport.ToPaginatedResponseAsync();
    }
}
