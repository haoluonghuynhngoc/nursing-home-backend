using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReportCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReportCategories.Handlers;
internal sealed class CreateCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<HealthReportCategory> _categoryRepository = unitOfWork.Repository<HealthReportCategory>();
    public async Task<MessageResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var healthReportCategory = new HealthReportCategory
        {
            Name = request.Name
        };
        await _categoryRepository.CreateAsync(healthReportCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
