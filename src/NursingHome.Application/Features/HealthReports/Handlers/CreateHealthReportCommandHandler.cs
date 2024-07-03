using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class CreateHealthReportCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateHealthReportCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    private readonly IGenericRepository<MeasureUnit> _measureUnitRepository = unitOfWork.Repository<MeasureUnit>();
    public async Task<MessageResponse> Handle(CreateHealthReportCommand request, CancellationToken cancellationToken)
    {
        if (!await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId, cancellationToken))
        {
            throw new NotFoundException(nameof(Elder), request.ElderId);
        }
        foreach (var healthReportDetail in request.HealthReportDetails)
        {
            if (!await _healthCategoryRepository.ExistsByAsync(_ => _.Id == healthReportDetail.HealthCategoryId, cancellationToken))
            {
                throw new NotFoundException(nameof(HealthCategory), healthReportDetail.HealthCategoryId);
            }
            foreach (var healthReportDetailMeasure in healthReportDetail.HealthReportDetailMeasures)
            {
                var measureUnit = await _measureUnitRepository.FindByAsync(_
                    => _.Id == healthReportDetailMeasure.MeasureUnitId)
                    ?? throw new NotFoundException($"Measure Unit Have Id {healthReportDetailMeasure.MeasureUnitId} Is Not Found");

                healthReportDetailMeasure.Status = measureUnit.MinValue <= healthReportDetailMeasure.Value
                    && measureUnit.MaxValue >= healthReportDetailMeasure.Value
                    ? HealthReportDetailMeasureStatus.Normal : HealthReportDetailMeasureStatus.Warning;

                if (measureUnit.HealthCategoryId != healthReportDetail.HealthCategoryId)
                {
                    throw new FieldResponseException(608, $"Measure Unit Have Id {healthReportDetailMeasure.MeasureUnitId} Not In The Health Category");
                }
            }
        }
        var healthReport = request.Adapt<HealthReport>();
        await _healthReportRepository.CreateAsync(healthReport, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
