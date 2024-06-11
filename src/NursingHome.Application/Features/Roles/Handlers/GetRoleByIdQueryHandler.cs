using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Roles.Models;
using NursingHome.Application.Features.Roles.Queries;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Roles.Handlers;
internal sealed class GetRoleByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRoleByIdQuery, RoleResponse>
{
    private readonly IGenericRepository<Role> _roleRepository = unitOfWork.Repository<Role>();
    public async Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByAsync<RoleResponse>(_ => _.Id == request.Id, cancellationToken);

        return role != null ? role : throw new NotFoundException(nameof(Role), request.Id);
    }
}
