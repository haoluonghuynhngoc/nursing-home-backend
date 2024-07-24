using LinqKit;
using MediatR;
using NursingHome.Application.Features.EmployeeTypes.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.EmployeeTypes.Queries;
public sealed record GetAllEmployeeTypeQuery : PaginationRequest<EmployeeType>, IRequest<PaginatedResponse<EmployeeTypeResponse>>
{
    public EmployeeTypeName? Name { get; set; }
    public override Expression<Func<EmployeeType, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => !Name.HasValue || _.Name == Name);
        return Expression;
    }
}
