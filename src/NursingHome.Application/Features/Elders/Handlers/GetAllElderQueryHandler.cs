using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Elders.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class GetAllElderQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllElderQuery, PaginatedResponse<ElderResponse>>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<PaginatedResponse<ElderResponse>> Handle(GetAllElderQuery request, CancellationToken cancellationToken)
    {
        var elders = await _elderRepository.FindAsync<ElderResponse>(
            request.PageIndex,
            request.PageSize,
            request.GetExpressions(),
            request.GetOrder(),
            cancellationToken
            );
        return await elders.ToPaginatedResponseAsync();
    }
}
