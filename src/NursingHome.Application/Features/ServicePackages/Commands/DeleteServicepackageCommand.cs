using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.ServicePackages.Commands;
public record DeleteServicepackageCommand(int Id) : IRequest<MessageResponse>;