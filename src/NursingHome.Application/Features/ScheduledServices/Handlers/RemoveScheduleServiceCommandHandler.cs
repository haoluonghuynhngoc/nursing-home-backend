using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ScheduledServices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ScheduledServices.Handlers;
internal class RemoveScheduleServiceCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveScheduleServiceCommand, MessageResponse>
{
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
    public async Task<MessageResponse> Handle(RemoveScheduleServiceCommand request, CancellationToken cancellationToken)
    {
        var scheduledService = await _scheduledServiceRepository.FindByAsync(x => x.Id == request.Id,
            includeFunc: _ => _.Include(x => x.ScheduledServiceDetails).ThenInclude(x => x.ScheduledTimes)
        , cancellationToken: cancellationToken);
        if (scheduledService is null)
        {
            throw new NotFoundException(nameof(ScheduledService), request.Id);
        }

        foreach (var detail in scheduledService.ScheduledServiceDetails)
        {
            detail.ScheduledTimes.Clear();
        }
        scheduledService.ScheduledServiceDetails.Clear();

        await _scheduledServiceRepository.DeleteAsync(scheduledService);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
