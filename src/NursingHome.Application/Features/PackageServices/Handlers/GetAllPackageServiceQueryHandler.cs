using LinqKit;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServices.Models;
using NursingHome.Application.Features.PackageServices.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageServices.Handlers;
internal sealed class GetAllPackageServiceQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageServiceQuery, PaginatedResponse<PackageServiceResponse>>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageCategory> _packageTypeRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PaginatedResponse<PackageServiceResponse>> Handle(GetAllPackageServiceQuery request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageCategoryName.ServicePackage)
    ?? throw new NotFoundException($"Package Type Have Name {PackageCategoryName.ServicePackage} Is Not Found");

        var expression = request.GetExpressions();
        expression = expression.And(_ => _.PackageRegisterTypeId == packageType.Id);

        var users = await _packageRepository.FindAsync<PackageServiceResponse>(
            request.PageIndex,
            request.PageSize,
            expression,
            request.GetOrder(),
            cancellationToken
            );
        return await users.ToPaginatedResponseAsync();
    }
}
