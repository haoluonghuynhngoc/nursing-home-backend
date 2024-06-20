using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
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
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.FindCurrentUserAsync();

        if (await _userRepository.ExistsByAsync(_ => _.Id != user.Id && _.PhoneNumber == request.PhoneNumber))
        {
            throw new FieldResponseException(600, $"Phone number Is {request.PhoneNumber} already exists.");
        }
        if (await _userRepository.ExistsByAsync(_ => _.Id != user.Id && _.Email == request.Email))
        {
            throw new FieldResponseException(601, $"Email Is {request.Email} already exists.");
        }
        if (await _userRepository.ExistsByAsync(_ => _.Id != user.Id && _.CCCD == request.CCCD))
        {
            throw new FieldResponseException(602, $"CCCD Is {request.CCCD} already exists.");
        }
        request.Adapt(user);
        await userManager.UpdateNormalizedEmailAsync(user);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.UserUpdatedProfileSuccess);
    }
}
