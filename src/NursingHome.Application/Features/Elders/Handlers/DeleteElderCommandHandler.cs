using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class DeleteElderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(DeleteElderCommand request, CancellationToken cancellationToken)
    {
        var elder = await _elderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (elder == null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);

        }
        await _elderRepository.DeleteAsync(elder);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);

    }
}
