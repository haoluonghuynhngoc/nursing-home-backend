using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Records.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Records.Handlers;
internal sealed class UpdateRecordCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateRecordCommand, MessageResponse>
{
    private readonly IGenericRepository<Record> _recordRepository = unitOfWork.Repository<Record>();
    public async Task<MessageResponse> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.FindByAsync(_ => _.Id == request.Id)
            ?? throw new NotFoundException($"Record Have Id {request.Id} Is Not Found");
        request.Adapt(record);
        await _recordRepository.UpdateAsync(record);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
