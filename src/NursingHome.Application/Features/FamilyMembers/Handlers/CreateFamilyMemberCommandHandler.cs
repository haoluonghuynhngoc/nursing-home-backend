using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Handlers;
using NursingHome.Application.Features.FamilyMembers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.FamilyMembers.Handlers;
internal class CreateFamilyMemberCommandHandler(IUnitOfWork unitOfWork,
    ILogger<CreateElderCommandHandler> logger) : IRequestHandler<CreateFamilyMemberCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<FamilyMember> _familyMemberRepository = unitOfWork.Repository<FamilyMember>();
    public async Task<MessageResponse> Handle(CreateFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        if (!await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId, cancellationToken))
        {
            throw new NotFoundException(nameof(Room), request.ElderId);
        }
        if (await _familyMemberRepository.ExistsByAsync(_ => _.PhoneNumber == request.PhoneNumber && _.ElderId == request.ElderId))
        {
            throw new FieldResponseException(600, "Phone Number Is Conflit");
        }
        var familyMember = request.Adapt<FamilyMember>();
        familyMember.State = StateType.Active;

        await _familyMemberRepository.CreateAsync(familyMember);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
