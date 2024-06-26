﻿using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record SetPasswordCommand : IRequest<MessageResponse>
{
    public string? FullName { get; set; }
    public string NewPassword { get; set; } = default!;
}
