﻿using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.ServicePackages.Commands;
public record UpdateServicePackageCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Duration { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int ServicePackageCategoryId { get; set; }
    //public PackageType Type { get; set; } = default!;
    //public DateOnly StartRegistrationDate { get; set; }
    //public DateOnly EndRegistrationDate { get; set; }
    ////public DateOnly EndDate { get; set; }
    //public DateOnly? EventDate { get; set; }

    //public virtual ICollection<CreateServicePackageDateRequest> ServicePackageDates { get; set; } = new HashSet<CreateServicePackageDateRequest>();
}