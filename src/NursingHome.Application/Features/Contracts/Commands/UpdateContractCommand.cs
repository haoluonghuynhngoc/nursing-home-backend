using MediatR;
using Newtonsoft.Json;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record UpdateContractCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? NameCustomer { get; set; }
    public string? CCCD { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressCustomer { get; set; }
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Content { get; set; }
    public string? ImageContract { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
}
