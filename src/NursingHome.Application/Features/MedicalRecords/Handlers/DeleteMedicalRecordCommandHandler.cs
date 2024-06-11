using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MedicalRecords.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MedicalRecords.Handlers;
internal class DeleteMedicalRecordCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteMedicalRecordCommand, MessageResponse>
{
    private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository = unitOfWork.Repository<MedicalRecord>();
    public async Task<MessageResponse> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
    {
        var medicalRecord = await _medicalRecordRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (medicalRecord is null)
        {
            throw new NotFoundException(nameof(MedicalRecord), request.Id);
        }

        await _medicalRecordRepository.DeleteAsync(medicalRecord);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
