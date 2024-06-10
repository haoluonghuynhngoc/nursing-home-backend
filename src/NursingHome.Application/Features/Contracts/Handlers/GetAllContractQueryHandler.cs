using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Contracts.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal class GetAllContractQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllContractQuery, PaginatedResponse<ContractResponse>>
{
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    public async Task<PaginatedResponse<ContractResponse>> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
    {
        var paginContract = await _contractRepository.FindAsync<ContractResponse>(
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            expression: request.GetExpressions(),
            orderBy: request.GetOrder(),
            cancellationToken: cancellationToken
            );
        return await paginContract.ToPaginatedResponseAsync();
    }
}
