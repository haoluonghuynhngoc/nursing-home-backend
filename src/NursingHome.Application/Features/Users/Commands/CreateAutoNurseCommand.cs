using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record CreateAutoNurseCommand : IRequest<MessageResponse>
{
    public int TotalUser { get; set; }
    public RoleUserName Name { get; set; } = default!;
    public GenderStatus GenderStatus { get; set; }
}
