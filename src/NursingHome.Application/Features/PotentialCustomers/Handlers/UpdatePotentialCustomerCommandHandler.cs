using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var potentialCustomer = await _potentialCustomerRepository.FindByAsync(
           expression: _ => _.Id == request.Id
           , includeFunc: _ => _.Include(x => x.Users)
           ) ?? throw new NotFoundException($"Potential Customer Id {request.Id} Is Not Found");

        request.Adapt(potentialCustomer);

        var user = await _userRepository.FindAsync(_ =>
        request.Users.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);
        potentialCustomer.Users = user;

        await _potentialCustomerRepository.UpdateAsync(potentialCustomer);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
