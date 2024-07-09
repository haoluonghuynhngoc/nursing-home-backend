using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ScheduledServices.Models;
using NursingHome.Application.Features.ScheduledServices.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.ScheduledServices.Handlers;
internal class GetAllScheduledServiceQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllScheduledServiceQuery, PaginatedResponse<ScheduledServiceResponse>>
{
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();

    public async Task<PaginatedResponse<ScheduledServiceResponse>> Handle(GetAllScheduledServiceQuery request, CancellationToken cancellationToken)
    {
        var scheduledService = await _scheduledServiceRepository
             .FindAsync<ScheduledServiceResponse>(
                 request.PageIndex,
                 request.PageSize,
                 request.GetExpressions(),
                 request.GetOrder(),
                 cancellationToken);

        return await scheduledService.ToPaginatedResponseAsync();
    }
}