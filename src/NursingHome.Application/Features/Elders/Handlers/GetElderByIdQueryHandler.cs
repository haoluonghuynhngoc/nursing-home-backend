using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Elders.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class GetElderByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetElderByIdQuery, ElderResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<ElderResponse> Handle(GetElderByIdQuery request, CancellationToken cancellationToken)
    {
        var elder = await _elderRepository.FindByAsync<ElderResponse>(x => x.Id == request.Id)
           ?? throw new NotFoundException($"Elder Have Id {request.Id} Is Not Found");
        return elder;
    }
}
