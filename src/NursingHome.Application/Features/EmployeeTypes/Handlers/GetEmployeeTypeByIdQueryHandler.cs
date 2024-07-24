using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.EmployeeTypes.Models;
using NursingHome.Application.Features.EmployeeTypes.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.EmployeeTypes.Handlers;
internal class GetEmployeeTypeByIdQueryhandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetEmployeeTypeByIdQuery, EmployeeTypeResponse>
{
    private readonly IGenericRepository<EmployeeType> _employeeTypeRepository = unitOfWork.Repository<EmployeeType>();
    public async Task<EmployeeTypeResponse> Handle(GetEmployeeTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var employeeType = await _employeeTypeRepository.FindByAsync<EmployeeTypeResponse>(x => x.Id == request.Id, cancellationToken);

        if (employeeType == null)
        {
            throw new NotFoundException(nameof(EmployeeType), request.Id);
        }

        return employeeType;
    }
}
