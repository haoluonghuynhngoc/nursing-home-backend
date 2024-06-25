using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class CreateElderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();

    public async Task<MessageResponse> Handle(CreateElderCommand request, CancellationToken cancellationToken)
    {
        if (await _elderRepository.ExistsByAsync(x => x.CCCD == request.CCCD))
        {
            throw new ConflictException($"Elder Have CCCD is {request.CCCD} In DataBase");
        }

        if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        if (!await _roomRepository.ExistsByAsync(_ => _.AvailableBed))
        {
            throw new FieldResponseException(604, "Room is full");
        }
        var diseaseCategories = await _diseaseCategoryRepository.FindAsync(_ =>
        request.MedicalRecord.DiseaseCategories.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);

        var room = await _roomRepository.FindByAsync(x => x.Id == request.RoomId
           , includeFunc: _ => _.Include(x => x.NursingPackage), cancellationToken: cancellationToken);
        if (room?.NursingPackageId == null)
        {
            throw new FieldResponseException(605, "Room Not Have Package");
        }
        var elder = request.Adapt<Elder>();
        request.Contract.UserId = request.UserId;
        request.Contract.NursingPackageId = room?.NursingPackageId; // Nếu đã sửa database rồi thì nhớ sửa lại int? sang int
        request.Contract.Price = room?.NursingPackage.Price ?? 0m;  // Cast Dữ liệu nếu phòng không có gói dịch vụ
        request.Contract.Status = ContractStatus.Pending;
        elder.MedicalRecord.DiseaseCategories = diseaseCategories; // add DiseaseCategories
        elder.Contracts = new List<Contract> {
            request.Contract.Adapt<Contract>()
        };
        await _elderRepository.CreateAsync(elder, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}

