using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.CareSchedules.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class GetTotalNumberOfNursesOnDutyQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetTotalNumberOfNursesOnDutyQuery, TotalNursesOnDutyResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<TotalNursesOnDutyResponse> Handle(GetTotalNumberOfNursesOnDutyQuery request, CancellationToken cancellationToken)
    {
        var listRooms = await _roomRepository.FindAsync(
            expression: _ => _.Elders.Count() > 0,
            includeFunc: _ => _.Include(r => r.Elders).Include(r => r.NursingPackage));

        return new TotalNursesOnDutyResponse
        {
            TotalNursesOnDuty = CalculateTotalNurses(listRooms.ToList())
        };
    }

    private int CalculateTotalNurses(List<Room> rooms)
    {
        // Tính tổng số lượng y tá cần thiết cho tất cả các phòng
        int totalNursesNeeded = rooms.Count() / 2;
        foreach (var room in rooms)
        {
            totalNursesNeeded += room.TotalNurseOnDuty;
        }
        // Chia tổng số lượng y tá cần thiết cho 6 và làm tròn lên
        int totalNursesRequired = (int)Math.Ceiling(totalNursesNeeded / 5.0);

        return totalNursesNeeded;
    }
}
