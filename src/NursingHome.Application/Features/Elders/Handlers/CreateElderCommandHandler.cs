using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class CreateElderCommandHandler(IUnitOfWork unitOfWork,
    ILogger<CreateElderCommandHandler> logger) : IRequestHandler<CreateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<MessageResponse> Handle(CreateElderCommand request, CancellationToken cancellationToken)
    {
        if (await _elderRepository.ExistsByAsync(x => x.CCCD == request.CCCD))
        {
            throw new FieldResponseException(602, $"CCCD Is {request.CCCD} already exists.");
        }
        if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        //if (await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId
        //&& request.Contract.Price != _.Price, cancellationToken))
        //{
        //    throw new FieldResponseException(614, $"The Price {request.Contract.Price} Does Not Match The Price Of The Nursing Package {request.NursingPackageId}.");
        //}

        var room = await _roomRepository.FindByAsync(x => x.Id == request.RoomId
           , includeFunc: _ => _.Include(x => x.NursingPackage).Include(x => x.Elders), cancellationToken: cancellationToken)
            ?? throw new NotFoundException($"Room Have Id {request.RoomId} Is Not Found");
        if (room.NursingPackageId == null)
        {
            throw new FieldResponseException(605, "Room Not Have Package");
        }
        if (room.NursingPackageId != request.NursingPackageId)
        {
            throw new FieldResponseException(606, $"This Room Does Not Contain A Nursing Package With Id {request.NursingPackageId}");
        }
        if (!(room.NursingPackage.Capacity > room.Elders.Count()))
        {
            throw new FieldResponseException(604, "Room is full");
        }
        var diseaseCategories = await _diseaseCategoryRepository.FindAsync(_ =>
        request.MedicalRecord.DiseaseCategories.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);
        var elder = request.Adapt<Elder>();
        elder.MedicalRecord.DiseaseCategories = diseaseCategories;
        request.Contract.UserId = request.UserId;
        request.Contract.NursingPackageId = room?.NursingPackageId; // Nếu đã sửa database rồi thì nhớ sửa lại int? sang int    
        request.Contract.Status = request.Contract.StartDate < DateOnly.FromDateTime(DateTime.Now)
            ? ContractStatus.Pending
            : ContractStatus.Valid;

        // Tính giá tiền theo tháng
        var monthsContact = ((request.Contract.EndDate.Year - request.Contract.StartDate.Year) * 12) + request.Contract.EndDate.Month - request.Contract.StartDate.Month;
        if (request.Contract.Price == 0)
        {
            request.Contract.Price = room?.NursingPackage.Price ?? 0m;
            request.Contract.Price *= monthsContact;
        }

        var contract = request.Contract.Adapt<Contract>();
        elder.Contracts = new List<Contract> {
            contract
        };
        await _elderRepository.CreateAsync(elder, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        // Thêm tự động order khi tạo mới elder
        await CreateOrderNursingPackage(elder, contract, request.UserId);

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
