using LinqKit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Features.Users.Queries;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class GetAllProfileUserQueryHandler(
    ICurrentUserService currentUserService,
    RoleManager<Role> roleManager,
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllProfileUserQuery, PaginatedResponse<UserResponse>>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<PaginatedResponse<UserResponse>> Handle(GetAllProfileUserQuery request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(RoleName.Admin);
        var expression = request.GetExpressions();
        expression = expression.And(u => u.UserRoles.Any(ur => ur.Role != role))
            .And(u => u.IsActive == true);

        var users = await _userRepository.FindAsync<UserResponse>(
            request.PageIndex,
            request.PageSize,
            expression,
            request.GetOrder(),
            cancellationToken
            );
        return await users.ToPaginatedResponseAsync();
    }
}
