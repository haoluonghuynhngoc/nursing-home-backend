using MediatR;
using NursingHome.Application.Features.Roles.Models;

namespace NursingHome.Application.Features.Roles.Queries;
public sealed record GetRolesQuery : IRequest<IList<RoleResponse>>;