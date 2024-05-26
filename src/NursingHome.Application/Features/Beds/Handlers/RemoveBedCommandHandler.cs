using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Beds.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Beds.Handlers;
internal sealed class RemoveBedCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<RemoveBedCommand, MessageResponse>
{
    private readonly IGenericRepository<Bed> _bedRepository = unitOfWork.Repository<Bed>();
    public async Task<MessageResponse> Handle(RemoveBedCommand request, CancellationToken cancellationToken)
    {

        var bed = await _bedRepository.FindByAsync(
             expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Bed Have Id {request.Id} Is Not Found");
        bed.Elder?.ClearDomainEvents(); // chưa test 
        bed.Room?.ClearDomainEvents(); // chưa test
        await _bedRepository.UpdateAsync(bed);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.DeletedSuccess);
    }
}
