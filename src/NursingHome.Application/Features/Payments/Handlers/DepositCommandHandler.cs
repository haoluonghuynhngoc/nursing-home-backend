using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Payments;
using NursingHome.Application.Features.Payments.Commands;
using NursingHome.Application.Models.Payments;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Payments.Handlers;
internal sealed class DepositCommandHandler(
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork,
    IMomoPaymentService momoPaymentService,
    IVnPayPaymentService vnPayPaymentService
    ) : IRequestHandler<DepositCommand, string>
{
    public async Task<string> Handle(DepositCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Method = request.Method,
            UserId = "Toi di code Dao",
            Status = "Toi di code Dao",
            Type = "Deposit",
            Description = "Deposit"
        };
        //await MomoPaymentServiceHandler(transaction, request.returnUrl);
        return await MomoPaymentServiceHandler(transaction, request.returnUrl);

    }
    private async Task<string> MomoPaymentServiceHandler(Transaction transaction, string returnUrl)
    {
        return await momoPaymentService.CreatePaymentAsync(new MomoPayment
        {
            Amount = (long)transaction.Amount,
            Info = transaction.Description,
            PaymentReferenceId = transaction.Id.ToString(),
            returnUrl = returnUrl
        });
    }
}

public class Transaction
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public double Amount { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? UserId { get; set; }

    public TransactionMethod Method { get; set; }

}
