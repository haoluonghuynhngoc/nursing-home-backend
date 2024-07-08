using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PotentialCustomers.Commands;
public record CreatePotentialCustomerCommand : IRequest<MessageResponse>
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public PotentialCustomerStatus Status { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public Guid UserId { get; set; }
}
