using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Models;
using NursingHome.Application.Features.PotentialCustomers.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class GetPotentialCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetPotentialCustomerByIdQuery, PotentialCustomerResponse>
{
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();
    public async Task<PotentialCustomerResponse> Handle(GetPotentialCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var potentialCustomer = await _potentialCustomerRepository
            .FindByAsync<PotentialCustomerResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Potential Customer Have Id {request.Id} Is Not Found");
        return potentialCustomer;
    }
}
