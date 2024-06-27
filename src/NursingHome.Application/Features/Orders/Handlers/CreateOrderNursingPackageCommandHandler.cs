using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class CreateOrderNursingPackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderNursingPackageCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();

    public async Task<MessageResponse> Handle(CreateOrderNursingPackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        foreach (var item in request.OrderDetails)
        {
            var nursingPakcage = await _contractRepository.FindByIdAsync(item.ContractId, cancellationToken);
            if (nursingPakcage == null)
            {
                throw new NotFoundException(nameof(Contract), item.ContractId);
            }
            item.Price = nursingPakcage.Price;
            item.ElderId = nursingPakcage.ElderId;
        }

        var order = request.Adapt<Order>();
        order.Status = OrderStatus.Paid;
        order.Method = TransactionMethod.Cash;
        order.Amount = (double)(request.OrderDetails?.Sum(detail => detail.Price) ?? 0);

        await _orderRepository.CreateAsync(order, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
