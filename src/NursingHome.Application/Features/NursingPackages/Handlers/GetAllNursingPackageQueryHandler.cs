using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.NursingPackages.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class GetAllNursingPackageQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllNursingPackageQuery, PaginatedResponse<NursingPackageResponse>>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<PaginatedResponse<NursingPackageResponse>> Handle(GetAllNursingPackageQuery request, CancellationToken cancellationToken)
    {
        var nursingPackages = await _nursingPackageRepository
            .FindAsync<NursingPackageResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await nursingPackages.ToPaginatedResponseAsync();
    }
}
