using NursingHome.Application.Features.Auth.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Contracts.Services;

public interface IJwtService
{
    public Task<AccessTokenResponse> GenerateTokenAsync(User user, long? expiresTime = null);
    public Task<User> ValidateRefreshTokenAsync(string refreshToken);

}