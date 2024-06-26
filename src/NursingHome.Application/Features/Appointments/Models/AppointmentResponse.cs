﻿using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Appointments.Models;
public record AppointmentResponse : BaseAppointmentResponse
{
    public BaseUserResponse User { get; set; } = default!;
    public BaseNursingPackageResponse NursingPackage { get; set; } = default!;
}
