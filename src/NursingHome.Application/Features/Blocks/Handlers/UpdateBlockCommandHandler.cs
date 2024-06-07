using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Blocks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Blocks.Handlers;
internal sealed class UpdateBlockCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateBlockCommand, MessageResponse>
{
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<MessageResponse> Handle(UpdateBlockCommand request, CancellationToken cancellationToken)
    {
        var block = await _blockRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Block Have Id {request.Id} Is Not Found");
        request.Adapt(block);
        await _blockRepository.UpdateAsync(block);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}

