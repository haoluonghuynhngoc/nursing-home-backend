using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class UpdateElderCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(UpdateElderCommand request, CancellationToken cancellationToken)
    {
        var elder = await _elderRepository.FindByAsync(
           expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Elder Have Id {request.Id} Is Not Found");
        request.Adapt(elder);
        await _elderRepository.UpdateAsync(elder);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
