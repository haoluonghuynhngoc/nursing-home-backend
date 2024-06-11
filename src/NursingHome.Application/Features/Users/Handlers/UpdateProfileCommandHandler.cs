using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class UpdateProfileCommandHandler(
    UserManager<User> userManager,
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateProfileCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.FindCurrentUserAsync();
        request.Adapt(user);
        await userManager.UpdateNormalizedEmailAsync(user);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.UserUpdatedProfileSuccess);
    }
}
