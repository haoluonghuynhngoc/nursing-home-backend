using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        //if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId))
        //{
        //    throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);
        //}
        var nursingPackage = await _nursingPackageRepository.FindByAsync(_ => _.Id == request.NursingPackageId)
            ?? throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);

        var elder = await _elderRepository.FindByAsync(
              expression: _ => _.Id == request.ElderId,
              includeFunc: _ => _.Include(e => e.Contracts))
            ?? throw new NotFoundException($"Elder Have Id {request.ElderId} Is Not Found");

        var overlappingContracts = elder.Contracts.Where(_ => _.Status == ContractStatus.Valid &&
        ((_.StartDate < request.StartDate && request.StartDate < _.EndDate) ||
        (_.StartDate < request.EndDate && request.EndDate < _.EndDate))).ToList();

        if (overlappingContracts.Any())
        {
            var overlappingDetails = string.Join(", ", overlappingContracts.Select(c => $"Bắt Đầu: {c.StartDate.ToString("dd/MM/yyyy")}, Kết Thúc: {c.EndDate.ToString("dd/MM/yyyy")}"));
            throw new FieldResponseException(616, $"Thời gian trùng với ngày hết hạn của hợp đồng cũ: {overlappingDetails}");
        }
        //if (elder.Contracts.Any(_ => _.Status == ContractStatus.Valid))
        //{
        //    var contractCheck = elder.Contracts.Where(_ => _.Status == ContractStatus.Valid).FirstOrDefault();
        //    if (contractCheck != null)
        //    {
        //        if (contractCheck.StartDate < request.StartDate && request.StartDate < contractCheck.EndDate)
        //        {
        //            // Báo lỗi: Thời gian trùng với hợp đồng cũ còn hạn
        //            throw new InvalidOperationException("Thời gian trùng với hợp đồng cũ còn hạn.");
        //        }
        //    }
        //}
        if (elder.Contracts.Any(_ => _.Status == ContractStatus.Pending))
        {
            throw new BadRequestException("Elder Already Has A Pending Contract.");
        }

        var contract = new Contract();
        request.Adapt(contract);

        // Tính giá tiền theo tháng
        var monthsContact = ((contract.EndDate.Year - contract.StartDate.Year) * 12) + contract.EndDate.Month - contract.StartDate.Month;
        if (contract.Price == 0)
        {
            contract.Price = nursingPackage.Price;
            contract.Price *= monthsContact;
        }

        contract.Status = DateOnly.FromDateTime(DateTime.Now) >= contract.StartDate && DateOnly.FromDateTime(DateTime.Now) <= contract.EndDate
            ? ContractStatus.Valid
            : ContractStatus.Pending;

        if (contract.EndDate < DateOnly.FromDateTime(DateTime.Now))
        {
            contract.Status = ContractStatus.Expired;
        }

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
                Description = $"Người Lớn Tuổi {elder.Name} Đã Thanh Toán Chi Phí Gói Dưỡng Lão.",
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
