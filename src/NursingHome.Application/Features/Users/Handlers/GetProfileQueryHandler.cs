using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Features.Users.Queries;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal sealed class GetProfileQueryHandler(
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork,
    IPublisher publisher) : IRequestHandler<GetProfileQuery, UserResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<UserResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        //await publisher.Publish(new InitWalletEvent() with { UserId = userId }, cancellationToken);

        if (await _userRepository
            .FindByAsync<UserResponse>(_ => _.Id == userId, cancellationToken) is not { } userResponse)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return userResponse;
    }
}

