using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.MedicalRecords.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MedicalRecords.Handlers;
internal class GetMedicalRecordByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetMedicalRecordByIdQuery, MedicalRecordResponse>
{
    private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository = unitOfWork.Repository<MedicalRecord>();

    public async Task<MedicalRecordResponse> Handle(GetMedicalRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalRecord = await _medicalRecordRepository.FindByAsync<MedicalRecordResponse>(x => x.Id == request.Id, cancellationToken);

        if (medicalRecord == null)
        {
            throw new NotFoundException(nameof(MedicalRecord), request.Id);
        }

        return medicalRecord;
    }
}
