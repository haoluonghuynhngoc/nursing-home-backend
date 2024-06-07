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
        // kiểm tra phòng này có được sử dụng không bằng cách kiểm tra xem packageId có null không
        //List<Block> listBlock = await _blockRepository.Entities.Include(b => b.Rooms).ToListAsync();
        //foreach (var item in listBlock)
        //{
        //    item.TotalRoom = item.Rooms.Count;
        //    item.UsedRooms = item.Rooms.Count(r => r.PackageId != null);
        //    item.UnUsedRooms = item.TotalRoom - item.UsedRooms;
        //    await _blockRepository.UpdateAsync(item);
        //    await unitOfWork.CommitAsync();
        //}

        var paginListBlock = await _blockRepository.FindAsync<BlockResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.Name) || x.Name.Contains(request.Search)),
            orderBy: x => x.OrderBy(x => x.Name),
            cancellationToken: cancellationToken
            );
        return await paginListBlock.ToPaginatedResponseAsync();
    }
}
