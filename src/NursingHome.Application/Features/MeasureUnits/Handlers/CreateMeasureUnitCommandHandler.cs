using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MeasureUnits.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MeasureUnits.Handlers;
internal class CreateMeasureUnitCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMeasureUnitCommand, MessageResponse>
{
    private readonly IGenericRepository<MeasureUnit> _measureUnitRepository = unitOfWork.Repository<MeasureUnit>();
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    public async Task<MessageResponse> Handle(CreateMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        if (!await _healthCategoryRepository.ExistsByAsync(_ => _.Id == request.HealthCategoryId, cancellationToken))
        {
            throw new NotFoundException(nameof(HealthCategory), request.HealthCategoryId);
        }
        if (await _healthCategoryRepository.ExistsByAsync(_ => _.Id == request.HealthCategoryId
        && _.MeasureUnits.Any(mu => mu.Name == request.Name)))
        {
            throw new ConflictException($"Measure Units Have Name {request.Name} In Health Category Have Block ID Is {request.HealthCategoryId}");
        }
        var measureUnits = request.Adapt<MeasureUnit>();
        await _measureUnitRepository.CreateAsync(measureUnits, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
