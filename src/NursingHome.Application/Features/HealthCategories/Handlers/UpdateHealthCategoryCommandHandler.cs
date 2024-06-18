using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthCategories.Handlers;
internal class UpdateHealthCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateHealthCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();

    public async Task<MessageResponse> Handle(UpdateHealthCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _healthCategoryRepository.ExistsByAsync(_ => _.Id != request.Id && _.Name == request.Name))
        {
            throw new ConflictException($"Health Category Have Name {request.Name} In DataBase");
        }

        var healthCategory = await _healthCategoryRepository.FindByAsync(
     expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Health Category Have Id {request.Id} Is Not Found");
        request.Adapt(healthCategory);
        await _healthCategoryRepository.UpdateAsync(healthCategory);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
