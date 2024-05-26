using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Beds.Commands;
public sealed record RemoveBedCommand(int Id) : IRequest<MessageResponse>;
