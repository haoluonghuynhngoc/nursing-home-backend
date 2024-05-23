using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Features.Users.Queries;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal class GetUserIdQueryHandler(
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByAsync<UserResponse>(_ => _.Id == request.Id, cancellationToken);
        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        return user;
    }
}
