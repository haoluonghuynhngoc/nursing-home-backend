using NursingHome.Application.Models.Payments;

namespace NursingHome.Application.Contracts.Services.Payments;

public interface IVnPayPaymentService
{
    public Task<string> CreatePaymentAsync(VnPayPayment payment);

}