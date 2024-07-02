using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MeasureUnits.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MeasureUnits.Handlers;
internal class UpdateMeasureUnitsCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateMeasureUnitsCommand, MessageResponse>
{
    private readonly IGenericRepository<MeasureUnit> _measureUnitRepository = unitOfWork.Repository<MeasureUnit>();
    public async Task<MessageResponse> Handle(UpdateMeasureUnitsCommand request, CancellationToken cancellationToken)
    {
        //if (await _measureUnitRepository.ExistsByAsync(_ => _.Id != request.Id && _.Name == request.Name))
        //{
        //    throw new ConflictException($"Health Category Have Name {request.Name} In DataBase");
        //}
        // chưa check nếu nó trùng tên với cái khác trong db và healthCategory
        var measureUnit = await _measureUnitRepository.FindByAsync(
     expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Measure Unit Have Id {request.Id} Is Not Found");
        request.Adapt(measureUnit);
        await _measureUnitRepository.UpdateAsync(measureUnit);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
