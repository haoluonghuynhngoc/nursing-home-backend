using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReports.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReports.Handlers;
internal class CreateHealthReportCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateHealthReportCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<HealthReport> _healthReportRepository = unitOfWork.Repository<HealthReport>();
    public async Task<MessageResponse> Handle(CreateHealthReportCommand request, CancellationToken cancellationToken)
    {
        if (!await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId, cancellationToken))
        {
            throw new NotFoundException(nameof(Elder), request.ElderId);
        }
        var healthReport = request.Adapt<HealthReport>();
        await _healthReportRepository.CreateAsync(healthReport, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
