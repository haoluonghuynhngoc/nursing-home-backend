using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        var medicalRecord = await _medicalRecordRepository.FindByAsync(x => x.Id == request.Id
          , includeFunc: _ => _.Include(x => x.DiseaseCategories), cancellationToken: cancellationToken);

        if (medicalRecord is null)
        {
            throw new NotFoundException(nameof(MedicalRecord), request.Id);
        }

        request.Adapt(medicalRecord);

        var diseaseCategories = await _diseaseCategoryRepository.FindAsync(_ => request.DiseaseCategories.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);
        medicalRecord.DiseaseCategories = diseaseCategories;

        await _medicalRecordRepository.UpdateAsync(medicalRecord);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
