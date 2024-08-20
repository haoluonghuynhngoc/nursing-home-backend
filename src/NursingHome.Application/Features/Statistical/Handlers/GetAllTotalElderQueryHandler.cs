using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Statistical.Handlers;
internal sealed class GetAllTotalElderQueryhandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllTotalElderQuery, TotalElderResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<TotalElderResponse> Handle(GetAllTotalElderQuery request, CancellationToken cancellationToken)
    {
        //var totalElder = await _elderRepository.FindAsync(
        //    includeFunc: _ => _.Include(x => x.Contracts));
        var totalElder = await _elderRepository.FindAsync();
        return new TotalElderResponse
        {
            TotalElder = totalElder.Count(),
            // TotalElderValid = totalElder.Count(_ => _.Contracts.Any(a => a.Status == ContractStatus.Valid))
            TotalElderValid = totalElder.Count(_ => _.State == StateType.Active)
        };
    }
}
