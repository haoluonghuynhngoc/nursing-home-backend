using MediatR;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PotentialCustomers.Commands;
public record UpdatePotentialCustomerCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public PotentialCustomerStatus Status { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public ICollection<CreateUserRequest> Users { get; set; } = new HashSet<CreateUserRequest>();
}
