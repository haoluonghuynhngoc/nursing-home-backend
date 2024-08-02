using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal class UpdateContractCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateContractCommand, MessageResponse>
{
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();

    public async Task<MessageResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Contract Have Id {request.Id} Is Not Found");
        // chưa test hàm này 
        //DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        //if (today < contract.StartDate || today > contract.EndDate)
        //{
        //    throw new FieldResponseException(618, "The contract is not within the valid period");
        //}

        request.Adapt(contract);
        await _contractRepository.UpdateAsync(contract);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
