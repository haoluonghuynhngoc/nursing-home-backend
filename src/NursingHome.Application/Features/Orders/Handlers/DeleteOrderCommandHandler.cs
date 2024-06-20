using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class DeleteOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<MessageResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }

        await _orderRepository.DeleteAsync(order);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
