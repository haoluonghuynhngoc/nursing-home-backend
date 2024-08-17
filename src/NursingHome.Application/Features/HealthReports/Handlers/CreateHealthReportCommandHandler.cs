using Hangfire;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
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
    IEmailSender emailSender,
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
        var elder = await _elderRepository.FindByAsync(_ => _.Id == request.ElderId,
            includeFunc: _ => _.Include(x => x.User))
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
            await SendMail(healthReport, elder, "#DD0000", "Cảnh Báo Sức Khỏe");
        }
        else
        {
            SendNotification(healthReport.Id, "Báo Cáo Sức Khỏe",
                $"Người cao tuổi {elder.Name} đã được đo chỉ số sức khỏe ngày {healthReport.Date:dd/MM/yyyy}",
                elder.UserId, NotificationLevel.Information, cancellationToken);
            //await SendMailInformation(healthReport, elder);

            await SendMail(healthReport, elder, "#4CAF50", "Báo Cáo Sức Khỏe");
        }
        // đã check còn thiếu tối ưu data BackgroundJob.Enqueue(() => SendMailWarning(healthReport))

        return new MessageResponse(Resource.CreatedSuccess);
    }

    //
    public async Task SendMail(HealthReport healthReport, Elder elder, string collor, string title)
    {
        try
        {
            var healthDetails = new List<(string Name, string Value)>();

            foreach (var healthReportDetail in healthReport.HealthReportDetails)
            {
                var healthCategory = await _healthCategoryRepository.FindByAsync(_ => _.Id == healthReportDetail.HealthCategoryId)
                    ?? throw new NotFoundException(nameof(HealthCategory), healthReportDetail.HealthCategoryId);

                foreach (var healthReportDetailMeasures in healthReportDetail.HealthReportDetailMeasures)
                {
                    var measureaUnit = await _measureUnitRepository.FindByAsync(_ => _.Id == healthReportDetailMeasures.MeasureUnitId)
                       ?? throw new NotFoundException(nameof(MeasureUnit), healthReportDetailMeasures.MeasureUnitId);
                    healthDetails.Add((healthCategory.Name, healthReportDetailMeasures.Value.ToString() + "/" + measureaUnit.UnitType + " " + measureaUnit.Name));
                }
            }

            var emailSubject = $"Đo chỉ số sức khỏe ngày {healthReport.Date:dd/MM/yyyy}";
            var emailBody = $@"<!DOCTYPE html>
           <html lang='vi'>
           <head>
               <meta charset='UTF-8'>
               <meta name='viewport' content='width=device-width, initial-scale=1.0'>
               <title>Báo Cáo Sức Khỏe Của Cụ {elder.Name}</title>
               <style>
                   body {{
                       font-family: Arial, sans-serif;
                       line-height: 1.6;
                       color: #333;
                   }}
                   .container {{
                       width: 100%;
                       max-width: 600px;
                       margin: 0 auto;
                       padding: 20px;
                       border: 1px solid #ccc;
                       border-radius: 10px;
                       background-color: #f9f9f9;
                   }}
                   h2 {{
                        color: {collor};
                        font-size: 27px;
                        text-align: center; 
                   }}
                   ul {{
                       list-style-type: none;
                       padding: 0;
                   }}
                   ul li {{
                       padding: 10px;
                       margin-bottom: 5px;
                       background: #eee;
                       border-radius: 5px;
                   }}
                   .footer {{
                       margin-top: 20px;
                       text-align: center;
                   }}
               </style>
           </head>
           <body>
               <div class='container'>
                   <h2>{title}</h2>
                   <p>Xin chào {elder.User.FullName},</p>
                   <p>Chúng tôi xin gửi đến bạn báo cáo sức khỏe Của Cụ {elder.Name}.</p>
                   <h3>Kết Quả Khám Sức Khỏe</h3>
                   <ul>";

            // Lặp qua các chi tiết báo cáo sức khỏe và thêm vào email body
            foreach (var detail in healthDetails)
            {
                emailBody += $@"
            <li><strong>{detail.Name}</strong>: {detail.Value}</li>";
            }

            emailBody += $@"
                   </ul>
                   <h3>Đánh Giá Chung</h3>
                   <p>{healthReport.Notes}</p>
                   <div class='footer'>
                       <p>Xin cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi.</p>
                       <img src='https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff4dbf5a6-1495-4314-9e64-52e35d2564fd.png?alt=media&token=926dd20b-667a-431d-a1a7-dc7fec3243e5' alt='Health Report Image' style='max-width: 100%;'>
                   </div>
               </div>
           </body>
           </html>";
            if (elder.User.Email != null)
            {
                await emailSender.SendEmailAsync($"{elder.User.Email}", emailSubject, emailBody);
            }
        }
        catch (Exception ex)
        {
        }

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
