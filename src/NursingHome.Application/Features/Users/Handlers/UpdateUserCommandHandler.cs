using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class UpdateUserCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, MessageResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByAsync(
             expression: _ => _.Id == request.Id)
              ?? throw new NotFoundException(nameof(User), request.Id);

        if (await _userRepository.ExistsByAsync(_ => _.Id != request.Id && _.Email == request.Email))
        {
            throw new FieldResponseException(601, $"Email Is {request.Email} already exists.");
        }
        if (await _userRepository.ExistsByAsync(_ => _.Id != request.Id && _.CCCD == request.CCCD))
        {
            throw new FieldResponseException(602, $"CCCD Is {request.CCCD} already exists.");
        }
        request.Adapt(user);
        await _userRepository.UpdateAsync(user);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
