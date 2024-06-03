using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Records.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Records.Handlers;
internal sealed class CreateRecordCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateRecordCommand, MessageResponse>
{
    private readonly IGenericRepository<Record> _recordRepository = unitOfWork.Repository<Record>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
    {
        var elder = await _elderRepository.FindByAsync(_ => _.Id == request.ElderId)
             ?? throw new NotFoundException($"Elder Have Id {request.ElderId} Is Not Found");

        var record = new Record
        {
            Name = request.Name,
            BloodType = request.BloodType,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            Weight = request.Weight,
            Height = request.Height,
            Status = "Active",
            CurrentMedications = request.CurrentMedications,
            Allergy = request.Allergy,
            Note = request.Note,
            ElderId = request.ElderId,
            Elder = elder
        };
        await _recordRepository.CreateAsync(record);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
