using MediatR;
using NursingHome.Application.Features.Shifts.Models;

namespace NursingHome.Application.Features.Shifts.Queries;
public sealed record GetShiftByIdQuery(int Id) : IRequest<ShiftResponse>;
