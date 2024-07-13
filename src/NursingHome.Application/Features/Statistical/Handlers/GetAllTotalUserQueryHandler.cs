using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Statistical.Handlers;
internal sealed class GetAllTotalUserQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllTotalUserQuery, TotalUserResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<TotalUserResponse> Handle(GetAllTotalUserQuery request, CancellationToken cancellationToken)
    {
        //var listUser = await _userRepository.FindAsync(user => user.IsActive,
        //    includeFunc: user => user.Include(_ => _.UserRoles).ThenInclude(role => role.Role));

        //var totalCustomer = listUser.SelectMany(customer => customer.UserRoles)
        //    .Count(role => role.Role.Name == RoleUserName.Customer.ToString());

        //var totalDirector = listUser.SelectMany(director => director.UserRoles)
        //    .Count(role => role.Role.Name == RoleUserName.Director.ToString());

        //var totalManager = listUser.SelectMany(manager => manager.UserRoles)
        //    .Count(role => role.Role.Name == RoleUserName.Manager.ToString());

        //var totalStaff = listUser.SelectMany(staff => staff.UserRoles)
        //    .Count(role => role.Role.Name == RoleUserName.Staff.ToString());

        //var totalNurse = listUser.SelectMany(nurse => nurse.UserRoles)
        //    .Count(role => role.Role.Name == RoleUserName.Nurse.ToString());

        //return new TotalUserResponse
        //{
        //    TotalUser = listUser.Count,
        //    TotalCustomer = totalCustomer,
        //    TotalDirector = totalDirector,
        //    TotalManager = totalManager,
        //    TotalNurse = totalNurse,
        //    TotalStaff = totalStaff,
        //};
        var listUser = await _userRepository.FindAsync(user => user.IsActive,
            includeFunc: user => user.Include(_ => _.UserRoles).ThenInclude(role => role.Role));

        var roleCounts = listUser
            .SelectMany(user => user.UserRoles.Select(userRole => new { user.Id, RoleName = (userRole.Role.Name?.ToString() ?? "Unknown") }))
            .Distinct()
            .GroupBy(userRole => userRole.RoleName)
            .ToDictionary(g => g.Key, g => g.Count());

        var totalUnknown = roleCounts.GetValueOrDefault("Unknown", 0);

        return new TotalUserResponse
        {
            TotalUser = listUser.Count,
            TotalCustomer = roleCounts.GetValueOrDefault(RoleUserName.Customer.ToString(), 0),
            TotalDirector = roleCounts.GetValueOrDefault(RoleUserName.Director.ToString(), 0),
            TotalManager = roleCounts.GetValueOrDefault(RoleUserName.Manager.ToString(), 0),
            TotalNurse = roleCounts.GetValueOrDefault(RoleUserName.Nurse.ToString(), 0),
            TotalStaff = roleCounts.GetValueOrDefault(RoleUserName.Staff.ToString(), 0),
        };
    }
}
