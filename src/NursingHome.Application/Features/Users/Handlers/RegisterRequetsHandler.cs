using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Users.Handlers;
internal class RegisterRequetsHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<RegisterRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var accountLogin = request.UserName;
        if (request.RoleName.IsNullOrEmpty() || request.RoleName == RoleName.Customer)
        {
            accountLogin = request.PhoneNumber;
        }
        var roleUser = request.RoleName switch
        {
            "director" => RoleName.Director,
            "manager" => RoleName.Manager,
            "staff" => RoleName.Staff,
            "nurse" => RoleName.Nurse,
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
