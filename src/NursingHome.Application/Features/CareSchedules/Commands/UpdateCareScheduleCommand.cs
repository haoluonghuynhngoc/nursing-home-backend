using MediatR;
using NursingHome.Application.Features.NurseSchedule.Models;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.CareSchedules.Commands;
public sealed record UpdateCareScheduleCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public ICollection<CreateNurseScheduleRequest> NurseSchedules { get; set; } = new HashSet<CreateNurseScheduleRequest>();
}
