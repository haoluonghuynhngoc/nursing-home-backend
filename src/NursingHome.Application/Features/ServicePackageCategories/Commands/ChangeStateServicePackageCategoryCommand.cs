using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.ServicePackageCategories.Commands;
public sealed record ChangeStateServicePackageCategoryCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public StateType State { get; set; }
}
