using MediatR;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Users.Queries;
public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserResponse>;