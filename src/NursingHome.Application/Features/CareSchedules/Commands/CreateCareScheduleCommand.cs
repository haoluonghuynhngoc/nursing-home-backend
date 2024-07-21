﻿using MediatR;
using NursingHome.Application.Features.NurseSchedules.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Commands;
public sealed record CreateCareScheduleCommand : IRequest<MessageResponse>
{

    public ICollection<DateOnly> Dates { get; set; } = new List<DateOnly>();
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public ICollection<CreateNurseScheduleRequest> NurseSchedules { get; set; } = new HashSet<CreateNurseScheduleRequest>();
}
