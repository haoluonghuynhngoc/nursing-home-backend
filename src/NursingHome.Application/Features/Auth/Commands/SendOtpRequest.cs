using MediatR;
using NursingHome.Application.Models;
using NursingHome.Shared.Converters;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed record SendOtpRequest : IRequest<MessageResponse>
{
    [NormalizePhone]
    public string PhoneNumber { get; init; } = default!;
}
