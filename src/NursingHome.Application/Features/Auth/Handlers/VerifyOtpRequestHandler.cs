﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Features.Auth.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Auth.Handlers;
internal sealed class VerifyOtpRequestHandler(
    UserManager<User> userManager,
    IJwtService jwtService) : IRequestHandler<VerifyOtpRequest, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(VerifyOtpRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.PhoneNumber);

        if (user is null)
        {
            throw new UnauthorizedAccessException(Resource.Unauthorized);
        }

        var result = await userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, request.Otp);

        if (!result)
        {
            throw new UnauthorizedAccessException(Resource.Unauthorized);
        }

        return await jwtService.GenerateTokenAsync(user, 60);
    }
}
