using MediatR;
using NursingHome.Application.Features.Auth.Models;
using System.ComponentModel;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed record LoginRequest : IRequest<AccessTokenResponse>
{
    [DefaultValue("admin")]
    public string Username { get; init; } = default!;

    [DefaultValue("admin")]
    public string Password { get; init; } = default!;

}