using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Features.Shifts.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Shifts.Handlers;
internal sealed class GetAllShiftQueryhandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllShiftQuery, PaginatedResponse<ShiftResponse>>
{
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    public async Task<PaginatedResponse<ShiftResponse>> Handle(GetAllShiftQuery request, CancellationToken cancellationToken)
    {
        var shiftList = await _shiftRepository.FindAsync<ShiftResponse>(
               pageIndex: request.PageIndex,
               pageSize: request.PageSize,
               request.GetExpressions(),
               orderBy: request.GetOrder(),
               cancellationToken: cancellationToken
               );
        return await shiftList.ToPaginatedResponseAsync();
    }
}
