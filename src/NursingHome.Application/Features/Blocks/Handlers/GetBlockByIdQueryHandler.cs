using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.Blocks.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Blocks.Handlers;
internal sealed class GetBlockByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetBlockByIdQuery, BlockResponse>
{
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<BlockResponse> Handle(GetBlockByIdQuery request, CancellationToken cancellationToken)
    {
        var block = await _blockRepository.FindByAsync<BlockResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Block Have Id {request.Id} Is Not Found");
        return block;
    }
}
