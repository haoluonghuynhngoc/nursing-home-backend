using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegisterTypes.Models;
using NursingHome.Application.Features.PackageRegisterTypes.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageRegisterTypes.Handlers;
internal class GetAllPackageRegisterTypeQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageRegisterTypeQuery, PaginatedResponse<PackageRegisterTypeResponse>>
{
    private readonly IGenericRepository<PackageRegisterType> _packageRegisterTypeRepository = unitOfWork.Repository<PackageRegisterType>();
    public async Task<PaginatedResponse<PackageRegisterTypeResponse>> Handle(GetAllPackageRegisterTypeQuery request, CancellationToken cancellationToken)
    {
        var paginPackageRegisterType = await _packageRegisterTypeRepository.FindAsync<PackageRegisterTypeResponse>(
           pageIndex: request.PageNumber,
           pageSize: request.PageSize,
           expression: x =>
               (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.NameRegister) || x.NameRegister.Contains(request.Search)),
           orderBy: x => x.OrderByDescending(x => x.Id),
           cancellationToken: cancellationToken
           );
        return await paginPackageRegisterType.ToPaginatedResponseAsync();
    }
}
