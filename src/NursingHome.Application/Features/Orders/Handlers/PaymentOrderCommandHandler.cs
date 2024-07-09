using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Payments;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Application.Models.Payments;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class PaymentOrderCommandHandler(
    IUnitOfWork unitOfWork,
    //ICurrentUserService currentUserService,
    IMomoPaymentService momoPaymentService,
    IVnPayPaymentService vnPayPaymentService) : IRequestHandler<PaymentOrderCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();

    public async Task<MessageResponse> Handle(PaymentOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(
            expression: _ => _.Id == request.OrderId) // && _.Method == TransactionMethod.None
            ?? throw new NotFoundException(nameof(NursingPackage), request.OrderId);

        var paymentUrl = request.Method switch
        {
            TransactionMethod.Momo => await MomoPaymentServiceHandler(order, request.returnUrl),
            TransactionMethod.VnPay => await VnPayPaymentServiceHandler(order, request.returnUrl),
            _ => "Payment Success"
        };

        return new MessageResponse(paymentUrl);
    }
    private async Task<string> MomoPaymentServiceHandler(Order order, string returnUrl)
    {
        return await momoPaymentService.CreatePaymentAsync(new MomoPayment
        {
            Amount = (long)order.Amount,
            Info = order.Description,
            PaymentReferenceId = order.PaymentReferenceId.ToString(),
            returnUrl = returnUrl
        });
    }

    private async Task<string> VnPayPaymentServiceHandler(Order order, string returnUrl)
    {
        return await vnPayPaymentService.CreatePaymentAsync(new VnPayPayment
        {
            Amount = (long)order.Amount,
            Info = order.Description,
            PaymentReferenceId = order.Id.ToString(),
            Time = order.CreatedAt.Value,
            returnUrl = returnUrl
        });
    }
}
