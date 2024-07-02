using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MeasureUnits.Commands;
public sealed record RemoveMeasureUnitCommand(int Id) : IRequest<MessageResponse>;

