using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageRegister.Commands;
public sealed record AddPackageRegisterRoomCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid? PackageRegisterId { get; set; }
    [JsonIgnore]
    public List<int>? Rooms { get; set; }
    //public int DurationMonth { get; set; }
}
