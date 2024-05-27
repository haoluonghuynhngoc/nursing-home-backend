using LinqKit;
using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Elders.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class GetElderWithPaginationQueryHandler(
    ICurrentUserService currentUserService,

    IUnitOfWork unitOfWork) : IRequestHandler<GetElderWithPaginationQuery, PaginatedResponse<ElderResponse>>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<PaginatedResponse<ElderResponse>> Handle(GetElderWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var expression = request.GetExpressions();
        expression = expression.Or(e =>
        (e.Status == request.Status || request.Status == null) &&
        (e.Gender == request.Gender || request.Gender == null) &&
        (e.InDate == request.InDate || request.InDate == null) &&
        (e.OutDate == request.OutDate || request.OutDate == null));

        var elders = await _elderRepository.FindAsync<ElderResponse>(
            request.PageIndex,
            request.PageSize,
            expression,
            request.GetOrder(),
            cancellationToken
            );
        return await elders.ToPaginatedResponseAsync();
    }
}
