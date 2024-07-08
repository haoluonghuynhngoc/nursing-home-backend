using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Appointments.Commands;
public record ChangeStatusAppointmentCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public AppointmentStatus Status { get; set; }
}
