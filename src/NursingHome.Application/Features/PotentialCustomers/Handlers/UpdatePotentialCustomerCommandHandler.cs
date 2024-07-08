using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class UpdatePotentialCustomerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePotentialCustomerCommand, MessageResponse>
{
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(UpdatePotentialCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var potentialCustomer = await _potentialCustomerRepository.FindByAsync(
           expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Potential Customer Id {request.Id} Is Not Found");

        request.Adapt(potentialCustomer);
        await _potentialCustomerRepository.UpdateAsync(potentialCustomer);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
