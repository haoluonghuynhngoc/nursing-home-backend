using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.EmployeeTypes.Models;
using NursingHome.Application.Features.EmployeeTypes.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.EmployeeTypes.Handlers;
internal class GetAllEmployeeTypeQueryCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllEmployeeTypeQuery, PaginatedResponse<EmployeeTypeResponse>>
{
    private readonly IGenericRepository<EmployeeType> _employeeTypeRepository = unitOfWork.Repository<EmployeeType>();

    public async Task<PaginatedResponse<EmployeeTypeResponse>> Handle(GetAllEmployeeTypeQuery request, CancellationToken cancellationToken)
    {
        var elders = await _employeeTypeRepository
            .FindAsync<EmployeeTypeResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await elders.ToPaginatedResponseAsync();
    }
}
