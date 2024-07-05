using MediatR;
using NursingHome.Application.Features.OrderDetails.Models;

namespace NursingHome.Application.Features.OrderDetails.Queries;
public sealed record GetAllDateServicePackageRegister : IRequest<List<DateOrderRegisterResponse>>
{
    public int? ElderId { get; set; }
    public int? ServicePackageId { get; set; }
}
