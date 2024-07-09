using Mapster;
using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PotentialCustomers.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.PotentialCustomers.Handlers;
internal class CreatePotentialCustomerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePotentialCustomerCommand, MessageResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<PotentialCustomer> _potentialCustomerRepository = unitOfWork.Repository<PotentialCustomer>();

    public async Task<MessageResponse> Handle(CreatePotentialCustomerCommand request, CancellationToken cancellationToken)
    {
        //if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        //{
        //    throw new NotFoundException(nameof(User), request.UserId);
        //}
        var user = await _userRepository.FindAsync(_ =>
        request.Users.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);

        var potentialCustomer = request.Adapt<PotentialCustomer>();
        potentialCustomer.Users = user;

        await _potentialCustomerRepository.CreateAsync(potentialCustomer, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
