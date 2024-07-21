using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Payments;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Features.ServicePackages.Models;
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
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();

    public async Task<MessageResponse> Handle(PaymentOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(
            expression: _ => _.Id == request.OrderId    // && _.Method == TransactionMethod.None
            , includeFunc: _ => _.Include(x => x.OrderDetails).ThenInclude(x => x.ServicePackage))
            ?? throw new NotFoundException(nameof(NursingPackage), request.OrderId);
        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        if (order.Status == OrderStatus.Paid)
        {
            throw new BadRequestException("Order Has Been Paid");
        }

        if (order.DueDate < currentDate)
        {
            throw new BadRequestException("Order Is Expired");
        }

        foreach (var item in order.OrderDetails)
        {
            var servicePackage = await _servicePackageRepository.FindByAsync<ServicePackageResponse>(x => x.Id == item.ServicePackageId, cancellationToken)
                ?? throw new NotFoundException(nameof(ServicePackage), item.ServicePackageId);
            if (servicePackage.TotalOrder >= servicePackage.RegistrationLimit)
            {
                throw new FieldResponseException(614, $"The service package has enough people, please choose another service");
            }
            if (servicePackage.EndRegistrationDate < DateOnly.FromDateTime(DateTime.Today))
            {
                throw new FieldResponseException(615, $"The translation package has expired, please choose another service");
            }
        }
        order.Method = request.Method;
        order.PaymentReferenceId = Guid.NewGuid();
        await unitOfWork.CommitAsync(cancellationToken);

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
            //PaymentReferenceId = order.Id.ToString(),
            PaymentReferenceId = order.PaymentReferenceId.ToString(),
            Time = DateTime.UtcNow,
            //Time = order.CreatedAt != null ? order.CreatedAt.Value : DateTime.UtcNow,
            returnUrl = returnUrl
        });
    }
}
