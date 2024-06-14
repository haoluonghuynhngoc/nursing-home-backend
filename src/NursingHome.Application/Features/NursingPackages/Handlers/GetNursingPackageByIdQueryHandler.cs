using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.NursingPackages.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class GetNursingPackageByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetNursingPackageByIdQuery, NursingPackageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<NursingPackageResponse> Handle(GetNursingPackageByIdQuery request, CancellationToken cancellationToken)
    {
        var nursingPackage = await _nursingPackageRepository
            .FindByAsync<NursingPackageResponse>(x => x.Id == request.Id, cancellationToken);

        if (nursingPackage == null)
        {
            throw new NotFoundException(nameof(NursingPackage), request.Id);
        }

        return nursingPackage;
    }
}
