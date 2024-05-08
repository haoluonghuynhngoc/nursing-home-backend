using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Features.Auth.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Auth.Handlers;
internal sealed class LoginRequestHandler(
    UserManager<User> userManager,
    IJwtService jwtService) : IRequestHandler<LoginRequest, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);

        if (user == null)
        {
            throw new UnauthorizedAccessException(Resource.Unauthorized);
        }

        if (!await userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException(Resource.Unauthorized);
        }

        return await jwtService.GenerateTokenAsync(user);
    }
}
