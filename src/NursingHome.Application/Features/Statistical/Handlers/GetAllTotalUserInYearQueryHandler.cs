using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Statistical.Handlers;
internal class GetAllTotalUserInYearQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllTotalUserInYearQuery, Dictionary<int, TotalUserResponse>>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<Dictionary<int, TotalUserResponse>> Handle(GetAllTotalUserInYearQuery request, CancellationToken cancellationToken)
    {
        var listUser = await _userRepository.FindAsync(
            user => user.IsActive && user.CreatedAt.HasValue && user.CreatedAt.Value.Year == request.Year,
            includeFunc: user => user.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
        );

        var statisticalResponse = Enumerable.Range(1, 12).ToDictionary(i => i, i => new TotalUserResponse());
        foreach (var user in listUser)
        {
            if (user.CreatedAt.HasValue)
            {
                statisticalResponse[user.CreatedAt.Value.Month].TotalUser++;
                user.UserRoles.ToList().ForEach(userRole =>
                {
                    if (userRole.Role != null)
                    {
                        switch (userRole.Role.Name)
                        {
                            case RoleName.Customer:
                                statisticalResponse[user.CreatedAt.Value.Month].TotalCustomer++;
                                break;
                            case RoleName.Director:
                                statisticalResponse[user.CreatedAt.Value.Month].TotalDirector++;
                                break;
                            case RoleName.Manager:
                                statisticalResponse[user.CreatedAt.Value.Month].TotalManager++;
                                break;
                            case RoleName.Nurse:
                                statisticalResponse[user.CreatedAt.Value.Month].TotalNurse++;
                                break;
                            case RoleName.Staff:
                                statisticalResponse[user.CreatedAt.Value.Month].TotalStaff++;
                                break;
                            default:
                                break;
                        }
                    }
                });
            }

        }

        return statisticalResponse;
    }
}
