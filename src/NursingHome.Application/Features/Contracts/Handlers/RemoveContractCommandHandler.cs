using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal class RemoveContractCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<RemoveContractCommand, MessageResponse>
{
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(RemoveContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.FindByAsync(
                expression: _ => _.Id == request.Id)
                 ?? throw new NotFoundException(nameof(Contract), request.Id);
        var elder = await _elderRepository.FindByAsync(
                expression: _ => _.Id == contract.ElderId)
                 ?? throw new NotFoundException(nameof(Elder), contract.ElderId);
        elder.Status = ElderStatus.CancelledContract;
        contract.ReasonForCanceling = request.ReasonForCanceling;

        contract.Status = ContractStatus.Cancelled;
        await _contractRepository.UpdateAsync(contract);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.DeletedSuccess);
    }
}
