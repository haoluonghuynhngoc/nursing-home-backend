using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class ChangeMethodPaymentOrderCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeMethodPaymentOrderCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();

    public async Task<MessageResponse> Handle(ChangeMethodPaymentOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }
        request.Adapt(order);
        if (order.Method == TransactionMethod.Cash)
        {
            order.Status = OrderStatus.Paid;
            order.PaymentDate = DateTime.UtcNow;
        }
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
