using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.MedicalRecords.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.MedicalRecords.Handlers;
internal class GetMedicalRecordsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetMedicalRecordsQuery, PaginatedResponse<MedicalRecordResponse>>
{
    private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository = unitOfWork.Repository<MedicalRecord>();

    public async Task<PaginatedResponse<MedicalRecordResponse>> Handle(GetMedicalRecordsQuery request, CancellationToken cancellationToken)
    {
        var medicalRecords = await _medicalRecordRepository
            .FindAsync<MedicalRecordResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await medicalRecords.ToPaginatedResponseAsync();
    }
}
