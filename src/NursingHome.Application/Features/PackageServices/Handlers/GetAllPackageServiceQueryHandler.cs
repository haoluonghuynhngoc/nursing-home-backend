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
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<PaginatedResponse<PackageServiceResponse>> Handle(GetAllPackageServiceQuery request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageTypeName.ServicePackage)
    ?? throw new NotFoundException($"Package Type Have Name {PackageTypeName.ServicePackage} Is Not Found");

        var expression = request.GetExpressions();
        expression = expression.And(_ => _.PackageTypeId == packageType.Id);

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
