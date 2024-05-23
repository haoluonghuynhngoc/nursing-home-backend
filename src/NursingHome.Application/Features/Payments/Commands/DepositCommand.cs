using MediatR;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Payments.Commands;
public sealed record DepositCommand : IRequest<string>
{
    public double Amount { get; set; }
    public TransactionMethod Method { get; set; }

    [JsonIgnore]
    public string returnUrl { get; set; } = string.Empty;
}