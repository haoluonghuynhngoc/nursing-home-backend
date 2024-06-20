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

        //if (request.DiseaseCategories.Any())
        //{
        //    var diseaseCategories = new HashSet<DiseaseCategory>();
        //    foreach (var diseaseCategoryId in request.DiseaseCategories)
        //    {
        //        if (!await _diseaseCategoryRepository.ExistsByAsync(_ => _.Id == diseaseCategoryId, cancellationToken))
        //        {
        //            throw new NotFoundException(nameof(DiseaseCategory), diseaseCategoryId);
        //        }
        //        var diseaseCategory = await _diseaseCategoryRepository.FindByAsync(_ => _.Id == diseaseCategoryId)
        //            ?? throw new NotFoundException(nameof(DiseaseCategory), diseaseCategoryId);
        //        diseaseCategories.Add(diseaseCategory);
        //    }
        //    medicalRecord.DiseaseCategories = diseaseCategories;
        //}

        await _medicalRecordRepository.CreateAsync(medicalRecord, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
