using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Records.Models;
using NursingHome.Application.Features.Records.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Records.Handlers;
internal sealed class GetRecordByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetRecordByIdQuery, RecordResponse>
{
    private readonly IGenericRepository<Record> _recordRepository = unitOfWork.Repository<Record>();
    public async Task<RecordResponse> Handle(GetRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.FindByAsync<RecordResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Record Have Id {request.Id} Is Not Found");
        return record;
    }
}
