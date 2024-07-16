using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.OrderDates.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.OrderDates.Handlers;
internal class ChangeStatusOrderDayCommandHandler(ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeStatusOrderDayCommand, MessageResponse>
{
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<OrderDate> _orderDateRepository = unitOfWork.Repository<OrderDate>();
    public async Task<MessageResponse> Handle(ChangeStatusOrderDayCommand request, CancellationToken cancellationToken)
    {
        request.UserId = await currentUserService.FindCurrentUserIdAsync();
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        request.CompletedAt = DateTimeOffset.UtcNow.UtcDateTime;

        var orderDate = await _orderDateRepository.FindByAsync(
    expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Order Date Have Id {request.Id} Is Not Found");
        request.Adapt(orderDate);
        await _orderDateRepository.UpdateAsync(orderDate);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
