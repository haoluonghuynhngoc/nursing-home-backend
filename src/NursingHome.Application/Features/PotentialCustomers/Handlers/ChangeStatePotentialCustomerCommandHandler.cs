using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class ChangeStatePotentialCustomerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeStatePotentialCustomerCommand, MessageResponse>
{
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();

    public async Task<MessageResponse> Handle(ChangeStatePotentialCustomerCommand request, CancellationToken cancellationToken)
    {
        var potentialCustomer = await _potentialCustomerRepository.FindByAsync(
            expression: _ => _.Id == request.Id
            , includeFunc: _ => _.Include(x => x.Users)
            ) ?? throw new NotFoundException($"Potential Customer Id {request.Id} Is Not Found");
        request.Adapt(potentialCustomer);
        await _potentialCustomerRepository.UpdateAsync(potentialCustomer);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
