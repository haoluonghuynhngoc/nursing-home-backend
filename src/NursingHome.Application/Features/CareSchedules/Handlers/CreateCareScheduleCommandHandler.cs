using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class CreateCareScheduleCommandHandler(
     IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCareScheduleCommand, MessageResponse>
{
    private readonly IGenericRepository<CareSchedule> _careScheduleRepository = unitOfWork.Repository<CareSchedule>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(CreateCareScheduleCommand request, CancellationToken cancellationToken)
    {
        //if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        //{
        //    throw new NotFoundException(nameof(Room), request.RoomId);
        //}
        //foreach (var nurseSchedule in request.NurseSchedules)
        //{
        //    if (!await _userRepository.ExistsByAsync(_ => _.Id == nurseSchedule.UserId, cancellationToken))
        //    {
        //        throw new NotFoundException(nameof(User), nurseSchedule.UserId);
        //    }
        //    if (!await _shiftRepository.ExistsByAsync(_ => _.Id == nurseSchedule.ShiftId, cancellationToken))
        //    {
        //        //throw new NotFoundException(nameof(Shift), nurseSchedule.ShiftId);
        //        throw new FieldResponseException(607, $"Could Not Find Shift With Id {nurseSchedule.ShiftId}");
        //    }
        //}
        //// chưa check điều kiện logic gì hết  
        //var careSchedule = new CareSchedule();
        //request.Adapt(careSchedule);

        //await _careScheduleRepository.CreateAsync(careSchedule);
        //await unitOfWork.CommitAsync();

        // =============================================

        // Danh sách y tá, ngày, và phòng
        //var nurses = await _userRepository.FindAsync(); // Danh sách y tá
        //var dates = request.Dates; // Danh sách ngày
        //var rooms = await _roomRepository.FindAsync(); // Danh sách phòng
        //var shifts = await _shiftRepository.FindAsync(); // Danh sách ca làm việc

        //// Tạo một dictionary để theo dõi ngày nghỉ của từng y tá
        //var nurseDaysOff = new Dictionary<Guid, DateOnly>();

        //foreach (var date in dates)
        //{
        //    if (date.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        continue;
        //    }

        //    foreach (var room in rooms)
        //    {
        //        // Lọc y tá có sẵn và chưa nghỉ vào ngày hiện tại
        //        var availableNurses = nurses
        //            //.Where(n => n.Available &&
        //            //            (!nurseDaysOff.ContainsKey(n.Id) || nurseDaysOff[n.Id] != date))
        //            .ToList();

        //        // Tạo danh sách các ca làm việc cho ngày hiện tại
        //        var shiftsForDay = shifts.OrderBy(s => s.Id).ToList();

        //        foreach (var shift in shiftsForDay)
        //        {
        //            // Chọn y tá cho ca làm việc
        //            var nursesForShift = availableNurses
        //                .Take(2) // Giả sử cần 2 y tá cho mỗi ca, điều chỉnh nếu cần
        //                .ToList();

        //            foreach (var nurse in nursesForShift)
        //            {
        //                var nurseSchedule = new CareSchedule
        //                {
        //                    RoomId = room.Id,
        //                    Date = date,
        //                    NurseSchedules = new HashSet<NurseSchedule>
        //                    {
        //                        new NurseSchedule
        //                        {
        //                            UserId = nurse.Id,
        //                            Shifts = new HashSet<Shift> { shift }
        //                        }
        //                    }
        //                };

        //                await _careScheduleRepository.CreateAsync(nurseSchedule);

        //                // Nếu y tá làm ca đêm, ghi nhớ ngày nghỉ
        //                if (shift.Id == 4)
        //                {
        //                    nurseDaysOff[nurse.Id] = date.AddDays(1);
        //                }
        //            }

        //            // Cập nhật danh sách y tá có sẵn để loại bỏ những y tá đã được phân công vào ca này
        //            availableNurses = availableNurses
        //                .Except(nursesForShift)
        //                .ToList();
        //        }
        //    }
        //}

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
