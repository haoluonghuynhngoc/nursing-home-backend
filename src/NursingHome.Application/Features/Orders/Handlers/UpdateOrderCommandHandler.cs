using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class UpdateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateOrderCommand, MessageResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<MessageResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }

        request.Adapt(order);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
