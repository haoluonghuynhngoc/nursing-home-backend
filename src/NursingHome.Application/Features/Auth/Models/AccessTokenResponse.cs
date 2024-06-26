﻿namespace NursingHome.Application.Features.Auth.Models;
using NursingHome.Application.Common.Constants;

public sealed record AccessTokenResponse
{
    public string TokenType { get; } = Token.Bearer;

    public required string AccessToken { get; init; }

    public required long ExpiresIn { get; init; }
    public ICollection<string> ListRole { get; init; } = new List<string>();
    public required string RefreshToken { get; init; }
}
