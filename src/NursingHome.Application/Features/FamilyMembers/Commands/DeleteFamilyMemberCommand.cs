using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.FamilyMembers.Commands;
public sealed record DeleteFamilyMemberCommand(int Id) : IRequest<MessageResponse>;
