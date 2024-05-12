﻿using MediatR;

namespace NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
public sealed record UpdateProfileCommand : IRequest<MessageResponse>
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? CCCD { get; set; }
    public string? Address { get; set; }
    public string? DateOfBirth { get; set; }
}
