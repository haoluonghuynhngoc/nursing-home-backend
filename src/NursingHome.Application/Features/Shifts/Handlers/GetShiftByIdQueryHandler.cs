using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Features.Shifts.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Shifts.Handlers;
internal sealed class GetShiftByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetShiftByIdQuery, ShiftResponse>
{
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    public async Task<ShiftResponse> Handle(GetShiftByIdQuery request, CancellationToken cancellationToken)
    {
        var shift = await _shiftRepository.FindByAsync<ShiftResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Shift Have Id {request.Id} Is Not Found");
        return shift;
    }
}
