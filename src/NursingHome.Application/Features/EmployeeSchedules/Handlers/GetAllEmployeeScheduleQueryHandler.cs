using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.EmployeeSchedules.Models;
using NursingHome.Application.Features.EmployeeSchedules.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.EmployeeSchedules.Handlers;
internal class GetAllEmployeeScheduleQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllEmployeeScheduleQuery, PaginatedResponse<EmployeeSchedulesResponse>>
{
    private readonly IGenericRepository<EmployeeSchedule> _employeeScheduleRepository = unitOfWork.Repository<EmployeeSchedule>();

    public async Task<PaginatedResponse<EmployeeSchedulesResponse>> Handle(GetAllEmployeeScheduleQuery request, CancellationToken cancellationToken)
    {
        var employeeSchedule = await _employeeScheduleRepository
           .FindAsync<EmployeeSchedulesResponse>(
               request.PageIndex,
               request.PageSize,
               request.GetExpressions(),
               request.GetOrder(),
               cancellationToken);

        return await employeeSchedule.ToPaginatedResponseAsync();
    }
}
