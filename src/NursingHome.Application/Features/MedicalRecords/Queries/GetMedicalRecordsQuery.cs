using LinqKit;
using MediatR;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.MedicalRecords.Queries;
public record GetMedicalRecordsQuery : PaginationRequest<MedicalRecord>, IRequest<PaginatedResponse<MedicalRecordResponse>>
{
    public int? ElderId { get; set; }

    public override Expression<Func<MedicalRecord, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => !ElderId.HasValue || _.ElderId == ElderId);

        return Expression;
    }
}
