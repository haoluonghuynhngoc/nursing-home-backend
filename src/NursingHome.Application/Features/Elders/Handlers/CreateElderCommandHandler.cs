using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class CreateElderCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    // private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(CreateElderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _userRepository.FindByAsync(_ => _.Id == request.UserId)
             ?? throw new NotFoundException($"Customer Have Id {request.UserId} Is Not Found");
        //var nursingPackage = await _nursingPackageRepository.FindByAsync(_ => _.Id == request.NursingPackageId)
        //     ?? throw new NotFoundException($"Nursing Package Have Id {request.NursingPackageId} Is Not Found");
        var room = await _roomRepository.FindByAsync(_ => _.Id == request.RoomId)
             ?? throw new NotFoundException(nameof(Room), request.RoomId);

        var elder = new Elder
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            ImageUrl = request.ImageUrl,
            Address = request.Address,
            Nationality = request.Nationality,
            Status = ElderStatus.NotAddedContract,
            Notes = request.Notes,
            Room = room,
            User = customer,
            //ElderNursingPackages = new HashSet<ElderNursingPackage>
            //{
            //   new() {
            //       NursingPackage = nursingPackage
            //   }
            //},
        };
        await _elderRepository.CreateAsync(elder);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
