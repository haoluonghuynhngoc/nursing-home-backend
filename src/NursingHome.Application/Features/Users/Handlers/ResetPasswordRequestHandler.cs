using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class ResetPasswordRequestHandler(
    ICurrentUserService currentUserService,
    UserManager<User> userManager) : IRequestHandler<ResetPasswordRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.FindCurrentUserAsync();

        var result = await userManager.RemovePasswordAsync(user);

        if (!result.Succeeded)
        {
            throw new ValidationBadRequestException(result.Errors);
        }

        result = await userManager.AddPasswordAsync(user, request.NewPassword);

        if (!result.Succeeded)
        {
            throw new ValidationBadRequestException(result.Errors);
        }

        return new MessageResponse(Resource.PasswordResetSuccess);
    }
}
