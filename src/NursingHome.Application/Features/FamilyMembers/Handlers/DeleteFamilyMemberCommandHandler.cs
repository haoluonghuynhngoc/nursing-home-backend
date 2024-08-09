using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.FamilyMembers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.FamilyMembers.Handlers;
internal class DeleteFamilyMemberCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteFamilyMemberCommand, MessageResponse>
{
    private readonly IGenericRepository<FamilyMember> _familyMemberRepository = unitOfWork.Repository<FamilyMember>();
    public async Task<MessageResponse> Handle(DeleteFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        var familyMember = await _familyMemberRepository.FindByAsync
           (x => x.Id == request.Id, cancellationToken: cancellationToken)
           ?? throw new NotFoundException($"Family Member Have Id {request.Id} Is Not Found");
        familyMember.State = StateType.Deleted;

        await _familyMemberRepository.UpdateAsync(familyMember);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
