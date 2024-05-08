using NursingHome.Application.Models.Payments;

namespace NursingHome.Application.Contracts.Services.Payments;

public interface IMomoPaymentService
{
    public Task<string> CreatePaymentAsync(MomoPayment payment);
}