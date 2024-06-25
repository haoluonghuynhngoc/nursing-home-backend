using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal sealed class CreateContractCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateContractCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();

    public async Task<MessageResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        if (await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId))
        {
            throw new NotFoundException(nameof(Elder), request.ElderId);
        }
        if (await _userRepository.ExistsByAsync(_ => _.Id == request.UserId))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var contract = new Contract();
        request.Adapt(contract);

        contract.Status = ContractStatus.Pending;

        await _contractRepository.CreateAsync(contract);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
