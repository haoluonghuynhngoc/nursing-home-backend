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
internal sealed class UpdateDiseaseCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateDiseaseCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    public async Task<MessageResponse> Handle(UpdateDiseaseCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _diseaseCategoryRepository.ExistsByAsync(x => x.Id != request.Id && x.Name == request.Name && x.State == StateType.Active))
        {
            throw new ConflictException($"Disease Category Have Name {request.Name} In DataBase");
        }

        var diseaseCategory = await _diseaseCategoryRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Disease Category Id {request.Id} Is Not Found");
        request.Adapt(diseaseCategory);

        await _diseaseCategoryRepository.UpdateAsync(diseaseCategory);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
