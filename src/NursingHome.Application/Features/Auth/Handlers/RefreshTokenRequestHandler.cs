using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Features.Auth.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Auth.Handlers;
internal sealed class RefreshTokenRequestHandler(
    IJwtService jwtService,
    UserManager<User> userManager) : IRequestHandler<RefreshTokenRequest, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var user = await jwtService.ValidateRefreshTokenAsync(request.RefreshToken);

        if (user == null)
        {
            throw new UnauthorizedAccessException(Resource.InvalidRefreshToken);
        }

        await userManager.UpdateSecurityStampAsync(user);

        return await jwtService.GenerateTokenAsync(user);
    }
}