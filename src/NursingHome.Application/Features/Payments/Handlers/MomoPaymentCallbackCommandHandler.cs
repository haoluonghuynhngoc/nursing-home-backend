using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Payments.Commands;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Payments.Handlers;
internal sealed class MomoPaymentCallbackCommandHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<MomoPaymentCallbackCommand>
{
    public Task Handle(MomoPaymentCallbackCommand request, CancellationToken cancellationToken)
    {
        var payment = request.OrderId.ConvertToGuid();

        Console.WriteLine($"Payment: {payment}");
        Console.WriteLine(request);
        return Task.CompletedTask;
    }
}
