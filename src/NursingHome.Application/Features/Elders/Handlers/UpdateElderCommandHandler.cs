using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class UpdateElderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();

    public async Task<MessageResponse> Handle(UpdateElderCommand request, CancellationToken cancellationToken)
    {
        var roomElderName = await _elderRepository.FindByAsync(x => x.CCCD == request.CCCD);
        if (roomElderName != null)
        {
            throw new ConflictException($"Elder Have CMND is {request.Name} In DataBase");
        }
        var elder = await _elderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (elder is null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);
        }

        request.Adapt(elder);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);

    }
}

