using Microsoft.AspNetCore.Authentication.JwtBearer;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;

namespace NursingHome.WebApi.Extensions;

public static class JwtBearerOptionsExtensions
{
    public static void HandleEvents(this JwtBearerOptions options)
    {
        options.Events = new JwtBearerEvents
        {
            OnForbidden = context =>
            {
                throw new ForbiddenAccessException();
            },

            OnChallenge = context =>
            {
                throw new UnauthorizedAccessException(Resource.Unauthorized);
            },

            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                if (!string.IsNullOrEmpty(accessToken))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    }
}