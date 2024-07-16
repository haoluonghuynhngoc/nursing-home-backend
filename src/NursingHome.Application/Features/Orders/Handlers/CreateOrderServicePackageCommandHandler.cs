using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
internal class CreateOrderServicePackageCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService,
    IMomoPaymentService momoPaymentService,
    IVnPayPaymentService vnPayPaymentService) : IRequestHandler<CreateOrderServicePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(CreateOrderServicePackageCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();
        request.UserId = userId; //hơi thừa nhưng có thể sửa lại sau này
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

            var listOrderDetail = await _orderDetailRepository.FindAsync(_ => _.ElderId == item.ElderId
            && _.ServicePackageId == item.ServicePackageId
            && _.Status != OrderDetailStatus.Finalized, includeFunc: _ => _.Include(x => x.OrderDates));
            foreach (var orderDetail in listOrderDetail)
            {
                if (orderDetail.Type == OrderDetailType.RecurringDay)
                {
                    item.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                    {
                        if (orderDetail.OrderDates.Any(_ => _.Date.Day == date.Day))
                        {
                            throw new FieldResponseException(609, $"Elder already has this service package in Date Of Month {date.Day}");
                        }
                    });
                }
                if (orderDetail.Type == OrderDetailType.RecurringWeeks)
                {
                    item.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                    {
                        if (orderDetail.OrderDates.Any(_ => _.Date.DayOfWeek == date.DayOfWeek))
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
                            throw new FieldResponseException(611, $"Elder already has this service package in Date {date}");
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
            var servicePackage = await _servicePackageRepository.FindByIdAsync(item.ServicePackageId, cancellationToken)
                ?? throw new NotFoundException(nameof(ServicePackage), item.ServicePackageId);

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
            Time = order.CreatedAt.Value,
            returnUrl = returnUrl
        });
    }
}
