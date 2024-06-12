using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Users.Queries;
public sealed record GetAllProfileUserQuery : PaginationRequest<User>, IRequest<PaginatedResponse<UserResponse>>
{
    /// <summary>
    /// Search field is search for fullName or CCCD or userName or email or phoneNumber
    /// </summary>
    public string? Search { get; set; }
    public RoleUserName? RoleName { get; set; }
    public override Expression<Func<User, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.FullName, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.UserName, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.CCCD, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.Email, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.PhoneNumber, $"%{Search}%"));
        }
        if (RoleName.HasValue)
        {
            Expression = Expression.And(u => u.UserRoles.Any(ur => ur.Role.Name == RoleName.ToString()));
        }
        return Expression;
    }
}
