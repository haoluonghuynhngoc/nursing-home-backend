﻿using Mapster;
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
        request.Contract.Price = room?.NursingPackage.Price ?? 0m;
        request.Contract.Status = request.Contract.StartDate < DateOnly.FromDateTime(DateTime.Now)
            ? ContractStatus.Pending
            : ContractStatus.Valid;

        elder.Contracts = new List<Contract> {
            request.Contract.Adapt<Contract>()
        };
        await _elderRepository.CreateAsync(elder, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}

