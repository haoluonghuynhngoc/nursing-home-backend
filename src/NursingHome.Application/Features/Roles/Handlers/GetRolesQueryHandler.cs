using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Roles.Models;
using NursingHome.Application.Features.Roles.Queries;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Roles.Handlers;
internal sealed class GetRolesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRolesQuery, IList<RoleResponse>>
{
    private readonly IGenericRepository<Role> _roleRepository = unitOfWork.Repository<Role>();
    public async Task<IList<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.FindAsync<RoleResponse>(cancellationToken: cancellationToken);
    }
}
