using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class UpdateCareScheduleCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCareScheduleCommand, MessageResponse>
{
    // chưa xong
    private readonly IGenericRepository<CareSchedule> _careScheduleRepository = unitOfWork.Repository<CareSchedule>();
    public Task<MessageResponse> Handle(UpdateCareScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
