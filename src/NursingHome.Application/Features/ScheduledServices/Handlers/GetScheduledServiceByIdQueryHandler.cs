using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ScheduledServices.Models;
using NursingHome.Application.Features.ScheduledServices.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ScheduledServices.Handlers;
internal class GetScheduledServiceByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetScheduledServiceByIdQuery, ScheduledServiceResponse>
{
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
    public async Task<ScheduledServiceResponse> Handle(GetScheduledServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var scheduledService = await _scheduledServiceRepository.FindByAsync<ScheduledServiceResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($" Scheduled Service Have Id {request.Id} Is Not Found");

        return scheduledService;
    }
}
