﻿using Mapster;
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
internal class CreateOrderServicePackageCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService,
    IMomoPaymentService momoPaymentService,
    IVnPayPaymentService vnPayPaymentService) : IRequestHandler<CreateOrderServicePackageCommand, MessageOrderResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageOrderResponse> Handle(CreateOrderServicePackageCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();
        request.UserId = userId; //hơi thừa nhưng có thể sửa lại sau này
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        // check thời hạn servic packeg không được vượt quá  nursing package quăn lỗi 
        foreach (var item in request.OrderDetails)
        {
            var servicePackage = await _servicePackageRepository.FindByAsync<ServicePackageResponse>(x => x.Id == item.ServicePackageId, cancellationToken)
                ?? throw new NotFoundException(nameof(ServicePackage), item.ServicePackageId);
            if (servicePackage.Type == PackageType.OneDay)
            {
                if (servicePackage.RegistrationLimit > 0 && servicePackage.TotalOrder >= servicePackage.RegistrationLimit)
                {
                    throw new FieldResponseException(614, $"The service package has enough people, please choose another service");
                }
                if (servicePackage.EndRegistrationDate != DateOnly.MinValue && servicePackage.EndRegistrationDate < DateOnly.FromDateTime(DateTime.Today))
                {
                    throw new FieldResponseException(615, $"The translation package has expired, please choose another service");
                }
            }
            if (!await _elderRepository.ExistsByAsync(_ => _.Id == item.ElderId, cancellationToken))
            {
                throw new NotFoundException(nameof(Elder), item.ElderId);
            }

            var listOrderDetail = await _orderDetailRepository.FindAsync(_ => _.ElderId == item.ElderId
            && _.ServicePackageId == item.ServicePackageId
            && _.Status != OrderDetailStatus.Finalized, includeFunc: _ => _.Include(x => x.OrderDates)
            .Include(x => x.ServicePackage).Include(x => x.Order));

            foreach (var orderDetail in listOrderDetail)
            {
                if (orderDetail.Type == OrderDetailType.RecurringDay)
                {
                    item.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                    {
                        if (orderDetail.OrderDates.Any(_ => _.Date.Day == date.Day
                        && _.Date.Month == date.Month & _.Date.Year == date.Year))
                        {
                            throw new FieldResponseException(609, $"Elder already has this service package in Date Of Month {date.Day}");
                        }
                    });
                }
                if (orderDetail.Type == OrderDetailType.RecurringWeeks)
                {
                    item.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                    {
                        if (orderDetail.OrderDates.Any(_ => _.Date.DayOfWeek == date.DayOfWeek
                         && _.Date.Month == date.Month & _.Date.Year == date.Year))
                        {
                            throw new FieldResponseException(610, $"Elder already has this service package in day of the week {date.DayOfWeek}");
                        }
                    });
                }
                if (orderDetail.Type == OrderDetailType.One_Time)
                {
                    item.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                    {
                        if (orderDetail.OrderDates.Any(_ => _.Date == date))
                        {
                            throw new FieldResponseException(611, $"Elder already has this service package in Date {date.ToString("dd/MM/yyyy")} ");
                        }
                    });
                }
            }
            // end check

            if (item.Type == OrderDetailType.One_Time)
            {
                item.Status = OrderDetailStatus.NonRepeatable;
            }
            else
            {
                item.Status = OrderDetailStatus.Repeatable;
            }
            item.Price = servicePackage.Price * item.TotalFutureDates;
        }

        var order = request.Adapt<Order>();
        order.Status = OrderStatus.UnPaid;
        order.PaymentReferenceId = Guid.NewGuid();
        order.Amount = (double)(request.OrderDetails?.Sum(detail => detail.Price) ?? 0);
        var paymentUrl = request.Method switch
        {
            TransactionMethod.Momo => await MomoPaymentServiceHandler(order, request.returnUrl),
            TransactionMethod.VnPay => await VnPayPaymentServiceHandler(order, request.returnUrl),
            TransactionMethod.None => "The Order Has Been Saved In The System, Please Pay Before The Due Date",
            _ => "Payment Success"
        };

        if (request.Method == TransactionMethod.Momo || request.Method == TransactionMethod.VnPay)
        {
            order.PaymentUrl = paymentUrl;
        }

        await _orderRepository.CreateAsync(order, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageOrderResponse
        {
            OrderId = order.Id,
            Message = paymentUrl
        };
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
        Console.WriteLine($"VnPayPaymentServiceHandler {order.PaymentReferenceId}");
        return await vnPayPaymentService.CreatePaymentAsync(new VnPayPayment
        {
            Amount = (long)order.Amount,
            Info = order.Description,
            //PaymentReferenceId = order.Id.ToString(),
            PaymentReferenceId = order.PaymentReferenceId.ToString(),
            Time = order.CreatedAt != null ? order.CreatedAt.Value : DateTime.UtcNow,
            returnUrl = returnUrl
        });
    }
}
