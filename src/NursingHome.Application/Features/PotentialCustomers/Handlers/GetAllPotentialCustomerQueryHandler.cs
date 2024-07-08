using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Models;
using NursingHome.Application.Features.PotentialCustomers.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class GetAllPotentialCustomerQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPotentialCustomerQuery, PaginatedResponse<PotentialCustomerResponse>>
{
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();

    public async Task<PaginatedResponse<PotentialCustomerResponse>> Handle(GetAllPotentialCustomerQuery request, CancellationToken cancellationToken)
    {
        var potentialCustomer = await _potentialCustomerRepository.FindAsync<PotentialCustomerResponse>(
          pageIndex: request.PageIndex,
          pageSize: request.PageSize,
          expression: request.GetExpressions(),
          orderBy: request.GetOrder(),
          cancellationToken: cancellationToken
          );
        return await potentialCustomer.ToPaginatedResponseAsync();
    }
}
