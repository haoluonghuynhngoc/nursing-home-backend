using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class MomoPaymentCallbackCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<MomoPaymentCallbackCommand>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task Handle(MomoPaymentCallbackCommand request, CancellationToken cancellationToken)
    {
        var orderId = request.OrderId.ConvertToGuid();

        var order = await _orderRepository
            .FindByAsync(_ => _.PaymentReferenceId == orderId, cancellationToken: cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(Order), orderId);
        }

        if (request.IsSuccess)
        {
            order.Status = OrderStatus.Paid;
        }
        else
        {
            order.Status = OrderStatus.Failed;
        }

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
