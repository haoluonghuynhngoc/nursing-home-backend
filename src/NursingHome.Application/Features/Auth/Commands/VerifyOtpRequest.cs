using MediatR;
using NursingHome.Application.Features.Auth.Models;
using NursingHome.Shared.Converters;
namespace NursingHome.Application.Features.Auth.Commands;
public sealed record VerifyOtpRequest : IRequest<AccessTokenResponse>
{
    [NormalizePhone]
    public string PhoneNumber { get; init; } = default!;

    [TrimString(true)]
    public string Otp { get; init; } = default!;
}
