using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class VnPayPaymentCallbackCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<VnPayPaymentCallbackCommand>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task Handle(VnPayPaymentCallbackCommand request, CancellationToken cancellationToken)
    {
        var orderId = request.vnp_TxnRef?.ConvertToInteger();

        var order = await _orderRepository
            .FindByAsync(_ => _.Id == orderId, cancellationToken: cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(Order), orderId);
        }

        if (request.IsSuccess)
        {
            order.Status = OrderStatus.Completed;
        }
        else
        {
            order.Status = OrderStatus.Failed;
        }

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
