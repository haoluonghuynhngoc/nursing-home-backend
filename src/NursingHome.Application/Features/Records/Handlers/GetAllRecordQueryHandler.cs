using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Records.Models;
using NursingHome.Application.Features.Records.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Records.Handlers;
internal sealed class GetAllRecordQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllRecordQuery, PaginatedResponse<RecordResponse>>
{
    private readonly IGenericRepository<Record> _recordRepository = unitOfWork.Repository<Record>();
    public async Task<PaginatedResponse<RecordResponse>> Handle(GetAllRecordQuery request, CancellationToken cancellationToken)
    {
        var paginRecord = await _recordRepository.FindAsync<RecordResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.Name) || x.Name.Contains(request.Search)),
            orderBy: x => x.OrderByDescending(x => x.Id),
            cancellationToken: cancellationToken
            );
        return await paginRecord.ToPaginatedResponseAsync();
    }
}
