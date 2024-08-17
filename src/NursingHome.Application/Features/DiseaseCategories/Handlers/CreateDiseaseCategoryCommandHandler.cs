using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.DiseaseCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.DiseaseCategories.Handlers;
internal sealed class CreateDiseaseCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateDiseaseCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();

    public async Task<MessageResponse> Handle(CreateDiseaseCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _diseaseCategoryRepository.ExistsByAsync(x => x.Name == request.Name && x.State == StateType.Active))
        {
            throw new ConflictException($"Disease Category Have Name {request.Name} In DataBase");
        }

        var diseaseCategory = new DiseaseCategory();
        request.Adapt(diseaseCategory);

        await _diseaseCategoryRepository.CreateAsync(diseaseCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
