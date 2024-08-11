using MediatR;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Appointments.Commands;
public record CreateAppointmentCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string? Content { get; set; }
    public string? Reason { get; set; }
    public DateOnly Date { get; set; }
    // public TimeOnly Time { get; set; }
    [JsonIgnore]
    public AppointmentStatus Status => AppointmentStatus.Pending;
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public int? NursingPackageId { get; set; }
    public int? ContractId { get; set; }
    public ICollection<CreateElderAppointmentRequest> Elders { get; set; } = new HashSet<CreateElderAppointmentRequest>();
}
