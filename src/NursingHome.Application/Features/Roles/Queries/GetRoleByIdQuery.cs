using MediatR;
using NursingHome.Application.Features.Roles.Models;

namespace NursingHome.Application.Features.Roles.Queries;
public sealed record GetRoleByIdQuery(Guid Id) : IRequest<RoleResponse>;