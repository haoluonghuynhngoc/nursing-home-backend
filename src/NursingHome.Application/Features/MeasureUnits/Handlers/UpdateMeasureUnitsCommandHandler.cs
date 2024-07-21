using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MeasureUnits.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.MeasureUnits.Handlers;
internal class UpdateMeasureUnitsCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateMeasureUnitsCommand, MessageResponse>
{
    private readonly IGenericRepository<MeasureUnit> _measureUnitRepository = unitOfWork.Repository<MeasureUnit>();
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    public async Task<MessageResponse> Handle(UpdateMeasureUnitsCommand request, CancellationToken cancellationToken)
    {
        var measureUnit = await _measureUnitRepository.FindByAsync(
     expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Measure Unit Have Id {request.Id} Is Not Found");

        //if (await _healthCategoryRepository.ExistsByAsync(_ => _.Id == measureUnit.HealthCategoryId
        //&& _.MeasureUnits.Any(mu => mu.Name == request.Name)))
        //{
        //    throw new ConflictException($"Measure Units Have Name {request.Name} In Health Category Have Block ID Is {measureUnit.HealthCategoryId}");
        //}
        if (await _measureUnitRepository.ExistsByAsync(_ => _.Id != request.Id && _.Name == request.Name
        && _.State != StateType.Deleted && _.HealthCategoryId == measureUnit.HealthCategoryId))
        {
            throw new ConflictException($"Measure Units Have Name {request.Name} In Health Category Have Block ID Is {measureUnit.HealthCategoryId}");
        }
        request.Adapt(measureUnit);
        await _measureUnitRepository.UpdateAsync(measureUnit);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
