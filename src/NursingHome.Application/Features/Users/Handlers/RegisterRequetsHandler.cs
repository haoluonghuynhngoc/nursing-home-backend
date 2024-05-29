using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Handlers;
internal class RegisterRequetsHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<RegisterRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var accountLogin = request.UserName;
        if (request.RoleRegister == null || request.RoleRegister == RoleRegister.Customer)
        {
            accountLogin = request.PhoneNumber;
        }
        var roleUser = request.RoleRegister switch
        {
            RoleRegister.Director => RoleName.Director,
            RoleRegister.Manager => RoleName.Manager,
            RoleRegister.Staff => RoleName.Staff,
            RoleRegister.Nurse => RoleName.Nurse,
            _ => RoleName.Customer,
        };

        var user = new User
        {
            UserName = accountLogin,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            FullName = request.FullName,
            IsActive = true,
        };
        await userManager.CreateAsync(user, request.Password);
        await userManager.AddToRolesAsync(user, new[] { roleUser });
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreateUserSuccessMessage);
    }
}
