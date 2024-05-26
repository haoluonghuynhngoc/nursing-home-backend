using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class CreateElderCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<CreateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(CreateElderCommand request, CancellationToken cancellationToken)
    {
        var elder = new Elder
        {
            FullName = request.FullName,
            IdentityNumber = request.IdentityNumber,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            ImageUrl = request.ImageUrl,
            Address = request.Address,
            Nationality = request.Nationality,
            Status = request.Status,
            Notes = request.Notes,
            InDate = request.InDate,
            OutDate = request.OutDate,
            BedId = request.BedId,

        };
        await _elderRepository.CreateAsync(elder);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
