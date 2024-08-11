using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Elders.Queries;
public sealed record GetEldersQuery : PaginationRequest<Elder>, IRequest<PaginatedResponse<ElderResponse>>
{

    public string? Search { get; set; }
    public GenderStatus? Gender { get; set; }
    public StateType? State { get; set; }
    public Guid? UserId { get; set; }
    public bool? IsRoomTransfer { get; set; }
    public int? RoomId { get; set; }
    public bool? HasNoContract { get; set; }
    //public int? Month { get; set; }
    //public int? Year { get; set; }
    public override Expression<Func<Elder, bool>> GetExpressions()
    {

        Expression = Expression.And(u => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(u.Name, $"%{Search}%"));
        Expression = Expression.And(u => !Gender.HasValue || u.Gender == Gender);
        Expression = Expression.And(u => !UserId.HasValue || u.UserId == UserId);
        Expression = Expression.And(u => !RoomId.HasValue || u.RoomId == RoomId);
        Expression = Expression.And(u => !State.HasValue || u.State == State);
        //if (!Month.HasValue && !Year.HasValue)
        //{
        //    Expression = Expression.And(u => u.Contracts.Any(c => c.Status == ContractStatus.Valid
        //    && c.EndDate.Month == Month
        //    && c.EndDate.Year == Year));
        //}
        if (HasNoContract.HasValue && HasNoContract == true)
        {
            Expression = Expression.And(u =>
                u.State == StateType.Active && // Người dùng phải ở trạng thái Active
                u.Room != null && // Người dùng phải có phòng
                !u.Contracts.Any(c => c.Status == ContractStatus.Valid || c.Status == ContractStatus.Pending)
            );
        }
        if (IsRoomTransfer.HasValue && IsRoomTransfer == true)
        {
            Expression = Expression.And(u =>
                u.State == StateType.Active && // Người dùng phải ở trạng thái Active
                u.Room != null && // Người dùng phải có phòng
                u.Contracts.Any(c => c.Status == ContractStatus.Valid) && // Có ít nhất một hợp đồng hợp lệ
                u.Contracts
                    .Where(c => c.Status == ContractStatus.Valid)
                    .Any(c => u.Room.NursingPackageId != c.NursingPackageId)
            );
        }
        return Expression;
    }
}
