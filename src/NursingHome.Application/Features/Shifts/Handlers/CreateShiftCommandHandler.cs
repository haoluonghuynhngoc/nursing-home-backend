using Mapster;
using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Shifts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Shifts.Handlers;
internal sealed class CreateShiftCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateShiftCommand, MessageResponse>
{
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    public async Task<MessageResponse> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
    {
        var shift = new Shift();
        request.Adapt(shift);

        await _shiftRepository.CreateAsync(shift);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
