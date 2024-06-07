using MediatR;
using NursingHome.Application.Features.Auth.Models;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed record RefreshTokenRequest(string RefreshToken) : IRequest<AccessTokenResponse>;