using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.MedicalRecords.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.MedicalRecords.Handlers;
internal class UpdateMedicalRecordCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateMedicalRecordCommand, MessageResponse>
{
    private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository = unitOfWork.Repository<MedicalRecord>();
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();

    public async Task<MessageResponse> Handle(UpdateMedicalRecordCommand request, CancellationToken cancellationToken)
    {

        var medicalRecord = await _medicalRecordRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (medicalRecord is null)
        {
            throw new NotFoundException(nameof(MedicalRecord), request.Id);
        }

        request.Adapt(medicalRecord);

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

        await _medicalRecordRepository.UpdateAsync(medicalRecord);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
