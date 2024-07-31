using Hangfire;
using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Features.HealthReports.Commands;
using NursingHome.Application.Models;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using System.Text.Json;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class CreateHealthReportCommandHandler(
    IUnitOfWork unitOfWork,
    INotifier notifier) : IRequestHandler<CreateHealthReportCommand, MessageResponse>
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
        var elder = await _elderRepository.FindByAsync(_ => _.Id == request.ElderId)
            ?? throw new NotFoundException(nameof(Elder), request.ElderId);

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

        if (healthReport.HealthReportDetails.Any(_ => _.IsWarning))
        {
            SendNotification(healthReport.Id, "Cảnh Báo Báo Cáo Sức Khỏe",
                $"Người cao tuổi {elder.Name} có chỉ số sức khỏe “bất thường” ngày {healthReport.Date:dd/MM/yyyy}.",
                elder.UserId, NotificationLevel.Warning, cancellationToken);
        }
        else
        {
            SendNotification(healthReport.Id, "Báo Cáo Sức Khỏe",
                $"Người cao tuổi {elder.Name} đã được đo chỉ số sức khỏe ngày {healthReport.Date:dd/MM/yyyy}",
                elder.UserId, NotificationLevel.Information, cancellationToken);
        }

        return new MessageResponse(Resource.CreatedSuccess);
    }

    private void SendNotification(int id, string title, string content, Guid userId, NotificationLevel notificationLevel, CancellationToken cancellationToken)
    {

        var notificationMessage = new NotificationRequest
        {
            Type = NotificationType.ExpoPush,
            UserId = userId,
            Level = notificationLevel,
            Title = title,
            Content = content,
            Data = JsonSerializer.Serialize(new
            {
                Id = id,
                Entity = nameof(HealthReport)
            })
        };
        BackgroundJob.Enqueue(() => notifier.NotifyAsync(notificationMessage, true, cancellationToken));
    }
}
