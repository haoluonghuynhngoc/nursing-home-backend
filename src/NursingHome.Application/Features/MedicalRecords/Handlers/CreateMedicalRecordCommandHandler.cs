using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MedicalRecords.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MedicalRecords.Handlers;
internal class CreateMedicalRecordCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateMedicalRecordCommand, MessageResponse>
{
    private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository = unitOfWork.Repository<MedicalRecord>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    public async Task<MessageResponse> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
    {
        if (!await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId, cancellationToken))
        {
            throw new NotFoundException(nameof(Elder), request.ElderId);
        }

        if (await _medicalRecordRepository.ExistsByAsync(_ => _.ElderId == request.ElderId, cancellationToken))
        {
            throw new ConflictException(nameof(Elder), request.ElderId);
        }

        var medicalRecord = request.Adapt<MedicalRecord>();

        var diseaseCategories = await _diseaseCategoryRepository.FindAsync(_ => request.DiseaseCategories.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);
        medicalRecord.DiseaseCategories = diseaseCategories;

        await _medicalRecordRepository.CreateAsync(medicalRecord, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
