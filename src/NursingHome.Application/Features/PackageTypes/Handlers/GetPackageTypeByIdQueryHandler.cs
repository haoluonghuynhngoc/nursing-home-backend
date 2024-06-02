using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageTypes.Models;
using NursingHome.Application.Features.PackageTypes.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageTypes.Handlers;
internal sealed class GetPackageTypeByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPackageTypeByIdQuery, PackageTypeResponse>
{
    private readonly IGenericRepository<PackageCategory> _packageTypeRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PackageTypeResponse> Handle(GetPackageTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync<PackageTypeResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        return packageType;
    }
}
