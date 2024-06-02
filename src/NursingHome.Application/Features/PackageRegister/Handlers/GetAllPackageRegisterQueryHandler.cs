using LinqKit;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegister.Models;
using NursingHome.Application.Features.PackageRegister.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageRegister.Handlers;
internal sealed class GetAllPackageRegisterQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageRegisterQuery, PaginatedResponse<PackageRegisterResponse>>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageCategory> _packageTypeRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PaginatedResponse<PackageRegisterResponse>> Handle(GetAllPackageRegisterQuery request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageCategoryName.RegisterPackage)
            ?? throw new NotFoundException($"Package Type Have Name {PackageCategoryName.RegisterPackage} Is Not Found");

        var expression = request.GetExpressions();
        expression = expression.And(_ => _.PackageRegisterTypeId == packageType.Id);

        var users = await _packageRepository.FindAsync<PackageRegisterResponse>(
            request.PageIndex,
            request.PageSize,
            expression,
            request.GetOrder(),
            cancellationToken
            );
        return await users.ToPaginatedResponseAsync();
    }
}
