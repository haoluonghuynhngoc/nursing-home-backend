using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.FamilyMembers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.FamilyMembers.Handlers;
internal class UpdateFamilyMemberCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateFamilyMemberCommand, MessageResponse>
{
    private readonly IGenericRepository<FamilyMember> _familyMemberRepository = unitOfWork.Repository<FamilyMember>();
    public async Task<MessageResponse> Handle(UpdateFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        var familyMember = await _familyMemberRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Family Member Have Id {request.Id} Is Not Found");
        if (await _familyMemberRepository.ExistsByAsync(_ => _.Id != request.Id && _.State == StateType.Active
        && _.PhoneNumber == request.PhoneNumber && _.ElderId == familyMember.ElderId))
        {
            throw new FieldResponseException(600, "Phone Number Is Conflit");
        }

        request.Adapt(familyMember);
        await _familyMemberRepository.UpdateAsync(familyMember);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
