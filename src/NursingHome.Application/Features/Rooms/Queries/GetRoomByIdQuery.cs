using MediatR;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.Rooms.Queries;
public sealed record GetRoomByIdQuery(int Id) : IRequest<RoomResponse>;