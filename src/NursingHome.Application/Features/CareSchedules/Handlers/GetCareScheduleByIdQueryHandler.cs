using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.CareSchedules.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class GetCareScheduleByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetCareScheduleByIdQuery, CareScheduleResponse>
{
    private readonly IGenericRepository<CareSchedule> _careScheduleRepository = unitOfWork.Repository<CareSchedule>();
    public async Task<CareScheduleResponse> Handle(GetCareScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var careSchedule = await _careScheduleRepository.FindByAsync<CareScheduleResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Care Schedule Have Id {request.Id} Is Not Found");
        return careSchedule;
    }
}
