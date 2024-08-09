using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class DeleteElderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(DeleteElderCommand request, CancellationToken cancellationToken)
    {
        var elder = await _elderRepository.FindByAsync(x => x.Id == request.Id
        , includeFunc: _ => _.Include(x => x.Contracts), cancellationToken: cancellationToken);

        if (elder == null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);
        }
        if (elder.Contracts.Any(_ => _.Status == ContractStatus.Pending || _.Status == ContractStatus.Valid))
        {
            throw new FieldResponseException(623, "Elderly people with valid contracts or pending contracts");
        }
        elder.State = StateType.Deleted;
        await _elderRepository.UpdateAsync(elder);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);

    }
}
