using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class ChangePasswordRequestHandler(
    ICurrentUserService currentUserService,
    UserManager<User> userManager) : IRequestHandler<ChangePasswordRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.FindCurrentUserAsync();

        if (!await userManager.HasPasswordAsync(user))
        {
            throw new BadRequestException(Resource.UserNotHavePassword);
        }

        var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            throw new ValidationBadRequestException(result.Errors);
        }

        return new MessageResponse(Resource.PasswordChangeSuccess);
    }
}
