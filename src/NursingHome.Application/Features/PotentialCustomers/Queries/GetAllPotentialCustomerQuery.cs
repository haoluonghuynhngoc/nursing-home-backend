using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.PotentialCustomers.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.PotentialCustomers.Queries;
public record GetAllPotentialCustomerQuery : PaginationRequest<PotentialCustomer>, IRequest<PaginatedResponse<PotentialCustomerResponse>>
{
    public string? Search { get; set; }

    public override Expression<Func<PotentialCustomer, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.FullName, $"%{Search}%"));

        return Expression;
    }
}
