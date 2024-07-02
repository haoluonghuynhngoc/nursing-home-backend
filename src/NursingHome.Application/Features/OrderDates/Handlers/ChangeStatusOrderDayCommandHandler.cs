using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.OrderDates.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.OrderDates.Handlers;
internal class ChangeStatusOrderDayCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeStatusOrderDayCommand, MessageResponse>
{
    private readonly IGenericRepository<OrderDate> _orderDateRepository = unitOfWork.Repository<OrderDate>();
    public async Task<MessageResponse> Handle(ChangeStatusOrderDayCommand request, CancellationToken cancellationToken)
    {
        var orderDate = await _orderDateRepository.FindByAsync(
    expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Order Date Have Id {request.Id} Is Not Found");
        request.Adapt(orderDate);
        await _orderDateRepository.UpdateAsync(orderDate);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
