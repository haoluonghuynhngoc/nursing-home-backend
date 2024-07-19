using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Contracts.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Handlers;
internal sealed class CreateContractCommandHandler(ILogger<CreateContractCommandHandler> logger,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateContractCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<MessageResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        //if (!await _elderRepository.ExistsByAsync(_ => _.Id == request.ElderId))
        //{
        //    throw new NotFoundException(nameof(Elder), request.ElderId);
        //}
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId))
        {
            throw new NotFoundException(nameof(NursingPackage), request.UserId);
        }
        var elder = await _elderRepository.FindByAsync(
              expression: _ => _.Id == request.ElderId) ?? throw new NotFoundException($"Elder Have Id {request.ElderId} Is Not Found");

        request.Status = request.StartDate < DateOnly.FromDateTime(DateTime.Now)
            ? ContractStatus.Pending
            : ContractStatus.Valid;

        var contract = new Contract();
        request.Adapt(contract);

        contract.Status = ContractStatus.Pending;

        await _contractRepository.CreateAsync(contract);

        // Thêm tự động order khi tạo mới elder
        await CreateOrderNursingPackage(elder, contract, request.UserId);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
    private async Task CreateOrderNursingPackage(Elder elder, Contract contract, Guid userId)
    {

        try
        {
            var order = new Order
            {
                UserId = userId,
                Method = TransactionMethod.Cash,
                Status = OrderStatus.Paid,
                Description = $"Người Lớn Tuổi {elder.Name} Đã Thanh Toán Chi Phí Gói Dưỡng Lão Vào Ngày {DateOnly.FromDateTime(DateTime.Now)}.",
                Amount = (double)contract.Price,
                Content = "Payment For Nursing Care Service Package",
                Notes = "None",
                PaymentDate = DateTime.UtcNow,
                DueDate = DateOnly.FromDateTime(DateTime.Today),
                OrderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    Contract = contract,
                    Price = contract.Price,
                    ElderId = elder.Id,
                    Quantity = 1,
                    Notes = $"Pay for the elderly care package for the elderly person {elder.Name}",
                    Status = OrderDetailStatus.Finalized,
                    Type = OrderDetailType.One_Time,
                }
            }
            };
            await _orderRepository.CreateAsync(order);
            await unitOfWork.CommitAsync();
        }

        catch (Exception ex)
        {
            logger.LogError(ex, "An Error Occurred While Creating Order For Elder.");
        }
    }
}
