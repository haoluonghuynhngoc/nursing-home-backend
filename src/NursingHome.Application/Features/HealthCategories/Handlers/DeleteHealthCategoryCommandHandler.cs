﻿using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthCategories.Handlers;
internal class DeleteHealthCategoryCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteHealthCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    public async Task<MessageResponse> Handle(DeleteHealthCategoryCommand request, CancellationToken cancellationToken)
    {
        var healthCategory = await _healthCategoryRepository.FindByAsync
            (x => x.Id == request.Id, cancellationToken: cancellationToken)
            ?? throw new NotFoundException($"Health Category Have Id {request.Id} Is Not Found");

        await _healthCategoryRepository.DeleteAsync(healthCategory);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
