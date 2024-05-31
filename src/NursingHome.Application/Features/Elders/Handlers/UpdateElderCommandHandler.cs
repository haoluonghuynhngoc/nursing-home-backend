using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class UpdateElderCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    //private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    //private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(UpdateElderCommand request, CancellationToken cancellationToken)
    {

        //   var packageRegster = await _packageRepository.FindByAsync(_ => _.Id == request.PackageRegisterId)
        //?? throw new NotFoundException($"Package Register Have Id {request.PackageRegisterId} Is Not Found");
        //   var guardian = await _userRepository.FindByAsync(_ => _.Id == request.UserCustomerId)
        //        ?? throw new NotFoundException($"User Customer Have Id {request.UserCustomerId} Is Not Found");

        var elder = await _elderRepository.FindByAsync(
           expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Elder Have Id {request.Id} Is Not Found");
        request.Adapt(elder);
        await _elderRepository.UpdateAsync(elder);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
