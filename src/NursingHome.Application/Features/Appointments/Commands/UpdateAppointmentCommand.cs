using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Appointments.Commands;
public record UpdateAppointmentCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
}
