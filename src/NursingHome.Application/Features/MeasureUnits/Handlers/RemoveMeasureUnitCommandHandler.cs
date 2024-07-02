using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MeasureUnits.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.MeasureUnits.Handlers;
internal class RemoveMeasureUnitCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveMeasureUnitCommand, MessageResponse>
{
    private readonly IGenericRepository<MeasureUnit> _measureUnitRepository = unitOfWork.Repository<MeasureUnit>();

    public async Task<MessageResponse> Handle(RemoveMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        var measureUnit = await _measureUnitRepository.FindByAsync(
              expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Measure Unit Have Id {request.Id} Is Not Found");
        measureUnit.State = StateType.Deleted;
        await _measureUnitRepository.UpdateAsync(measureUnit);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.DeletedSuccess);
    }
}
