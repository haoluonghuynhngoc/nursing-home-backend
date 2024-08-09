using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.FamilyMembers.Models;
using NursingHome.Application.Features.FamilyMembers.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.FamilyMembers.Handlers;
internal class GetFamilyMemberByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetFamilyMemberByIdQuery, FamilyMemberResponse>
{
    private readonly IGenericRepository<FamilyMember> _familyMemberRepository = unitOfWork.Repository<FamilyMember>();
    public async Task<FamilyMemberResponse> Handle(GetFamilyMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var familyMember = await _familyMemberRepository.FindByAsync<FamilyMemberResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Family Member Have Id {request.Id} Is Not Found");
        return familyMember;
    }
}
