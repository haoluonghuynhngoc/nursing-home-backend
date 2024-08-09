using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.FamilyMembers.Models;
using NursingHome.Application.Features.FamilyMembers.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.FamilyMembers.Handlers;
internal class GetAllFamilyMemberQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllFamilyMemberQuery, PaginatedResponse<FamilyMemberResponse>>
{
    private readonly IGenericRepository<FamilyMember> _familyMemberRepository = unitOfWork.Repository<FamilyMember>();
    public async Task<PaginatedResponse<FamilyMemberResponse>> Handle(GetAllFamilyMemberQuery request, CancellationToken cancellationToken)
    {
        var paginContract = await _familyMemberRepository.FindAsync<FamilyMemberResponse>(
           pageIndex: request.PageIndex,
           pageSize: request.PageSize,
           expression: request.GetExpressions(),
           orderBy: request.GetOrder(),
           cancellationToken: cancellationToken
           );
        return await paginContract.ToPaginatedResponseAsync();
    }
}
