using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Devices.Commands;
public sealed record DeleteDeviceCommand(int Id) : IRequest<MessageResponse>;
