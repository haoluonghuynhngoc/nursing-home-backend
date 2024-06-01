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
        var paginListContract = await _contractRepository.FindAsync<ContractResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.NameCustomer) || x.NameCustomer.Contains(request.Search)) &&
                (request.Status == null || x.Status == request.Status),
            orderBy: x => x.OrderBy(x => x.NameCustomer),
            cancellationToken: cancellationToken
            );
        return await paginListContract.ToPaginatedResponseAsync();
    }
}
