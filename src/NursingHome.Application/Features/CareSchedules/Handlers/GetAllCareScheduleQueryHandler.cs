using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.CareSchedules.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class GetAllCareScheduleQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllCareScheduleQuery, PaginatedResponse<CareScheduleResponse>>
{
    private readonly IGenericRepository<CareSchedule> _careScheduleRepository = unitOfWork.Repository<CareSchedule>();
    public async Task<PaginatedResponse<CareScheduleResponse>> Handle(GetAllCareScheduleQuery request, CancellationToken cancellationToken)
    {
        var paginCareSchedule = await _careScheduleRepository.FindAsync<CareScheduleResponse>(
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            expression: request.GetExpressions(),
            orderBy: request.GetOrder(),
            cancellationToken: cancellationToken
            );
        return await paginCareSchedule.ToPaginatedResponseAsync();
    }
}
