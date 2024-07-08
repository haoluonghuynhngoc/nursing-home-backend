using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class DeletePotentialCustomerCommandhandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePotentialCustomerCommand, MessageResponse>
{
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();

    public async Task<MessageResponse> Handle(DeletePotentialCustomerCommand request, CancellationToken cancellationToken)
    {
        var potentialCustomer = await _potentialCustomerRepository.FindByAsync(
       expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Potential Customer Have Id {request.Id} Is Not Found");

        await _potentialCustomerRepository.DeleteAsync(potentialCustomer);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
