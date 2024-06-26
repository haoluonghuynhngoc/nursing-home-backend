﻿using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Blocks.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Blocks.Handlers;
internal sealed class CreateBlockCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateBlockCommand, MessageResponse>
{
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<MessageResponse> Handle(CreateBlockCommand request, CancellationToken cancellationToken)
    {
        if (await _blockRepository.ExistsByAsync(x => x.Name == request.Name))
        {
            throw new ConflictException($"Block Have Name {request.Name} In DataBase");
        }

        var block = new Block();
        request.Adapt(block);

        await _blockRepository.CreateAsync(block);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}