using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Beds.Models;
using NursingHome.Application.Features.Beds.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Beds.Handlers;
internal sealed class GetAllBedQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllBedQuery, PaginatedResponse<BedResponse>>
{
    private readonly IGenericRepository<Bed> _bedRepository = unitOfWork.Repository<Bed>();
    public async Task<PaginatedResponse<BedResponse>> Handle(GetAllBedQuery request, CancellationToken cancellationToken)
    {
        var paginListBed = await _bedRepository.FindAsync<BedResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.Status) || x.Status.Contains(request.Search))
                && (request.RoomId == null || x.RoomId == request.RoomId),
            x => x.OrderByDescending(x => x.Id),
            cancellationToken: cancellationToken
            );
        return await paginListBed.ToPaginatedResponseAsync();
    }
}
