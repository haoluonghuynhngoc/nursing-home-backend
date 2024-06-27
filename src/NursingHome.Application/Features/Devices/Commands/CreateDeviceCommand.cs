using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Devices.Commands;
public sealed record CreateDeviceCommand : IRequest<MessageResponse>
{
    public string Token { get; set; } = default!;
}

