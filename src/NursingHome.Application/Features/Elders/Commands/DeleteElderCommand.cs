using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Elders.Commands;
public record DeleteElderCommand(int Id) : IRequest<MessageResponse>;