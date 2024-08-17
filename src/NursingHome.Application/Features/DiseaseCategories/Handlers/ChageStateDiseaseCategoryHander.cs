using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.DiseaseCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.DiseaseCategories.Handlers;
internal class ChageStateDiseaseCategoryHander(IUnitOfWork unitOfWork)
    : IRequestHandler<ChageStateDiseaseCategory, MessageResponse>
{
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    public async Task<MessageResponse> Handle(ChageStateDiseaseCategory request, CancellationToken cancellationToken)
    {
        var diseaseCategory = await _diseaseCategoryRepository
            .FindByAsync(x => x.Id == request.Id, includeFunc: _ => _.Include(x => x.MedicalRecords), cancellationToken: cancellationToken);

        if (diseaseCategory is null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }
        if (diseaseCategory.MedicalRecords.Count() > 0)
        {
            throw new FieldResponseException(628, "The disease category cannot remove because it is currently in use.");
        }
        request.Adapt(diseaseCategory);
        await _diseaseCategoryRepository.UpdateAsync(diseaseCategory);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
