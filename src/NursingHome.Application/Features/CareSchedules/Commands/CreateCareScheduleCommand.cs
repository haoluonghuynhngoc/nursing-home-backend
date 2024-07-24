using MediatR;
using NursingHome.Application.Features.EmployeeSchedules.Models;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Commands;
public sealed record CreateCareScheduleCommand : IRequest<MessageResponse>
{
    public int CareMonth { get; set; }
    public int CareYear { get; set; }
    public string? Notes { get; set; }
    //public int RoomId { get; set; }
    public ICollection<CreateRoomRequest> Rooms { get; set; } = new HashSet<CreateRoomRequest>();
    public ICollection<CreateEmployeeSchedulesRequest> EmployeeSchedules { get; set; } = new HashSet<CreateEmployeeSchedulesRequest>();
}
