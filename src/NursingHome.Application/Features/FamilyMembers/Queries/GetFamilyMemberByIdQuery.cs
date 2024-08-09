using MediatR;
using NursingHome.Application.Features.FamilyMembers.Models;

namespace NursingHome.Application.Features.FamilyMembers.Queries;
public sealed record GetFamilyMemberByIdQuery(int Id) : IRequest<FamilyMemberResponse>;
