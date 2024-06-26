﻿using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Notifications.Commands;
public sealed record DeleteListNotificationCommand : IRequest<MessageResponse>
{
    public IList<int> Ids { get; set; } = new List<int>();
}
