using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthCategories.Handlers;
internal class CreateHealthCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateHealthCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();

    public async Task<MessageResponse> Handle(CreateHealthCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _healthCategoryRepository.ExistsByAsync(x => x.Name == request.Name))
        {
            throw new ConflictException($"Health Category Have Name {request.Name} In DataBase");
        }

        var healthCategory = request.Adapt<HealthCategory>();
        await _healthCategoryRepository.CreateAsync(healthCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
