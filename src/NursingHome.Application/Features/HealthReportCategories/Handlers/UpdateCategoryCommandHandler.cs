using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReportCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReportCategories.Handlers;
internal class UpdateCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<HealthReportCategory> _categoryRepository = unitOfWork.Repository<HealthReportCategory>();
    public async Task<MessageResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var block = await _categoryRepository.FindByAsync(
             expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Health Report Category Have Id {request.Id} Is Not Found");
        request.Adapt(block);
        await _categoryRepository.UpdateAsync(block);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
