using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Shifts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Shifts.Handlers;
internal sealed class UpdateShiftCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateShiftCommand, MessageResponse>
{
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    public async Task<MessageResponse> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
    {
        var shift = await _shiftRepository.FindByAsync(
             expression: _ => _.Id == request.Id)
              ?? throw new NotFoundException(nameof(Shift), request.Id);
        request.Adapt(shift);
        await _shiftRepository.UpdateAsync(shift);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
