using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Handlers;
internal class RegisterUserSystemCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserSystemCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterUserSystemCommand request, CancellationToken cancellationToken)
    {
        var userCheck = await userManager.FindByNameAsync(request.UserName);
        if (userCheck != null)
        {
            throw new BadRequestException(Resource.UserAlreadyExists);
        }
        var roleUser = request.RoleRegister switch
        {
            RoleRegister.Director => RoleName.Director,
            RoleRegister.Manager => RoleName.Manager,
            RoleRegister.Staff => RoleName.Staff,
            _ => RoleName.Nurse,
        };

        var user = new User
        {
            UserName = request.UserName,
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
