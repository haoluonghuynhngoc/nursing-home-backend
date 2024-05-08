using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Shared.Extensions;
using System.Security.Claims;

namespace NursingHome.Infrastructure.Services;
public class CurrentUserService(
    UserManager<User> userManager,
    IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? CurrentUserId => CurrentUserPrincipal?.Identity?.Name;

    public ClaimsPrincipal? CurrentUserPrincipal => httpContextAccessor.HttpContext?.User;

    public string ServerUrl => string.Concat(httpContextAccessor?.HttpContext?.Request.Scheme, "://", httpContextAccessor?.HttpContext?.Request.Host.ToUriComponent()) ?? throw new NotFoundException("not have url server");

    public async Task<User> FindCurrentUserAsync()
    {
        if (CurrentUserPrincipal != null &&
            await userManager.GetUserAsync(CurrentUserPrincipal) is { } user)
            return user;

        throw new UnauthorizedAccessException(Resource.Unauthorized);
    }

    public Task<Guid> FindCurrentUserIdAsync()
    {
        if (CurrentUserId == null)
            throw new UnauthorizedAccessException(Resource.Unauthorized);

        return Task.FromResult(CurrentUserId.ConvertToGuid());
    }
}
