﻿using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Payments;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Application.Models.Payments;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class CreateOrderServicePackageCommandHandler(
    IUnitOfWork unitOfWork,
    IMomoPaymentService momoPaymentService,
    IVnPayPaymentService vnPayPaymentService) : IRequestHandler<CreateOrderServicePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(CreateOrderServicePackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        foreach (var item in request.OrderDetails)
        {
            if (!await _elderRepository.ExistsByAsync(_ => _.Id == item.ElderId, cancellationToken))
            {
                throw new NotFoundException(nameof(Elder), item.ElderId);
            }
            //if (!await _servicePackageRepository.ExistsByAsync(_ => _.Id == item.ServicePackageId, cancellationToken))
            //{
            //    throw new NotFoundException(nameof(ServicePackage), item.ServicePackageId);
            //}
            var servicePackage = await _servicePackageRepository.FindByIdAsync(item.ServicePackageId, cancellationToken)
                ?? throw new NotFoundException(nameof(ServicePackage), item.ServicePackageId);

            item.Type = servicePackage.Type switch
            {
                PackageType.OneDay => OrderDetailType.One_Time,
                PackageType.MultipleDays => OrderDetailType.Recurring,
                PackageType.WeeklyDays => OrderDetailType.Recurring,
                _ => OrderDetailType.Recurring
            };

            item.Price = servicePackage.Price * item.TotalDate;
        }

        var order = request.Adapt<Order>();
        order.Status = OrderStatus.UnPaid;
        order.PaymentReferenceId = Guid.NewGuid();
        order.Amount = (double)(request.OrderDetails?.Sum(detail => detail.Price) ?? 0);

        await _orderRepository.CreateAsync(order, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        var paymentUrl = request.Method switch
        {
            TransactionMethod.Momo => await MomoPaymentServiceHandler(order, request.returnUrl),
            TransactionMethod.VnPay => await VnPayPaymentServiceHandler(order, request.returnUrl),
            _ => "payment success"
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
