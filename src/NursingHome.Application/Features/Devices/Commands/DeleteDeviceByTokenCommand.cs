using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Devices.Commands;
public sealed record DeleteDeviceByTokenCommand(string Token) : IRequest<MessageResponse>;