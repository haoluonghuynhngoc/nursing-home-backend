using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Contracts.Queries;
public sealed record GetAllContractQuery : PaginationRequest<Contract>, IRequest<PaginatedResponse<ContractResponse>>
{

    public string? Search { get; set; }
    public ContractStatus? Status { get; set; }

    public override Expression<Func<Contract, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression
            .And(r => !Status.HasValue || r.Status == Status);
        return Expression;
    }

}
