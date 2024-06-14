using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.NursingPackages.Commands;
public sealed record AddNursingPackageToRoomCommand : IRequest<MessageResponse>
{
    public int NursingPackageId { get; set; }
    public List<int>? Rooms { get; set; }
}
