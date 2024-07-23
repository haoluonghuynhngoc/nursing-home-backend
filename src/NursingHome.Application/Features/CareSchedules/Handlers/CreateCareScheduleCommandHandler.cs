using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
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
    //public async Task<MessageResponse> Handle(CreateCareScheduleCommand request, CancellationToken cancellationToken)
    //{
    //    if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId))
    //    {
    //        throw new NotFoundException(nameof(Room), request.RoomId);
    //    }

    //    var allUsers = await _userRepository.FindAsync(isAsNoTracking: false);

    //    // Lọc người dùng dựa trên dữ liệu yêu cầu
    //    var users = allUsers.Where(user =>
    //        request.NurseSchedules
    //               .SelectMany(ns => ns.UserNurseSchedules)
    //               .Select(uns => uns.UserId)
    //               .Contains(user.Id)).ToList();

    //    var careSchedule = request.Adapt<CareSchedule>();

    //    foreach (var nurseSchedule in careSchedule.NurseSchedules)
    //    {
    //        var listUser = users.Where(user =>
    //            nurseSchedule.UserNurseSchedules
    //                         .Select(uns => uns.UserId)
    //                         .Contains(user.Id)).ToHashSet();

    //        foreach (var user in listUser)
    //        {
    //            // Kiểm tra xem UserNurseSchedule đã tồn tại chưa trước khi thêm mới
    //            if (!nurseSchedule.UserNurseSchedules.Any(uns => uns.UserId == user.Id))
    //            {
    //                nurseSchedule.UserNurseSchedules.Add(new UserNurseSchedule
    //                {
    //                    UserId = user.Id
    //                });
    //            }
    //        }
    //    }

    //    await _careScheduleRepository.CreateAsync(careSchedule);
    //    await unitOfWork.CommitAsync();

    //    return new MessageResponse(Resource.CreatedSuccess);
    //}
    public async Task<MessageResponse> Handle(CreateCareScheduleCommand request, CancellationToken cancellationToken)
    {
        if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId))
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }

        // Lấy danh sách các UserId từ request
        var userIds = request.NurseSchedules
                             .SelectMany(ns => ns.UserNurseSchedules)
                             .Select(uns => uns.UserId)
                             .Distinct()
                             .ToList();
        var users = await _userRepository.FindAsync(u => userIds.Contains(u.Id), isAsNoTracking: false);

        var careSchedule = request.Adapt<CareSchedule>();

        foreach (var nurseSchedule in careSchedule.NurseSchedules)
        {
            var listUserIds = nurseSchedule.UserNurseSchedules
                                           .Select(uns => uns.UserId)
                                           .Distinct()
                                           .ToHashSet();

            foreach (var userId in listUserIds)
            {
                var user = users.FirstOrDefault(u => u.Id == userId);
                if (user != null && !nurseSchedule.UserNurseSchedules.Any(uns => uns.UserId == user.Id))
                {
                    nurseSchedule.UserNurseSchedules.Add(new UserNurseSchedule
                    {
                        // thêm list  ngày ca trực ở đây 
                        UserId = user.Id
                    });
                }
            }
        }

        await _careScheduleRepository.CreateAsync(careSchedule);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
