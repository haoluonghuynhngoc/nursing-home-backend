using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.Blocks.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Blocks.Handlers;
internal sealed class GetAllBlocksQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllBlocksQuery, PaginatedResponse<BlockResponse>>
{
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();

    public async Task<PaginatedResponse<BlockResponse>> Handle(GetAllBlocksQuery request, CancellationToken cancellationToken)
    {
        var paginListBlock = await _blockRepository.FindAsync<BlockResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search)) &&
                (!request.TotalFloor.HasValue || x.TotalFloor == request.TotalFloor),
            orderBy: x => x.OrderBy(x => x.Name),
            cancellationToken: cancellationToken
            );
        // return new PaginatedResponse<BlockResponse>(blocks);
        return await paginListBlock.ToPaginatedResponseAsync();
    }
}
