using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Contracts.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal class GetContractByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetContractByIdQuery, ContractResponse>
{
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    public async Task<ContractResponse> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.FindByAsync<ContractResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Contract Have Id {request.Id} Is Not Found");
        return contract;
    }
}
