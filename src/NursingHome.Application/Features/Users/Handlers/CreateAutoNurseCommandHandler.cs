using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Handlers;
internal class CreateAutoNurseCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateAutoNurseCommand, MessageResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(CreateAutoNurseCommand request, CancellationToken cancellationToken)
    {
        int lastIndex = (await _userRepository
           .FindAsync(cancellationToken: cancellationToken)).MaxBy(_ => _.Index)?.Index ?? 0;

        var users = Enumerable.Range(1, request.TotalUser)
            .Select(rackIndex => new User
            {
                UserName = $"{request.Name}{lastIndex}",
                FullName = $"{request.Name}{lastIndex}",
                Index = ++lastIndex,
                IsActive = true,
                Gender = request.GenderStatus
            })
            .ToList();
        var roleUser = request.Name switch
        {
            RoleUserName.Director => RoleName.Director,
            RoleUserName.Manager => RoleName.Manager,
            RoleUserName.Staff => RoleName.Staff,
            RoleUserName.Customer => RoleName.Customer,
            _ => RoleName.Nurse,
        };
        foreach (var item in users)
        {
            await userManager.CreateAsync(item, "1");
            await userManager.AddToRolesAsync(item, new[] { roleUser });
        }

        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
