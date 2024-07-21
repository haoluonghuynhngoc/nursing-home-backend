using MediatR;
using NursingHome.Application.Features.CareServices.Models;

namespace NursingHome.Application.Features.CareServices.Queries;
public sealed record GetCareServiceQuery : IRequest<CareServiceResponse>
{
    public int RoomId { get; set; }
    public DateOnly Date { get; set; }
}
