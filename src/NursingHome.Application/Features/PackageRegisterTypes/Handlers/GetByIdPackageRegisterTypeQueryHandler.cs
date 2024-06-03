using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegisterTypes.Models;
using NursingHome.Application.Features.PackageRegisterTypes.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegisterTypes.Handlers;
internal class GetByIdPackageRegisterTypeQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetByIdPackageRegisterTypeQuery, PackageRegisterTypeResponse>
{
    private readonly IGenericRepository<PackageRegisterType> _packageRegisterTypeRepository = unitOfWork.Repository<PackageRegisterType>();
    public async Task<PackageRegisterTypeResponse> Handle(GetByIdPackageRegisterTypeQuery request, CancellationToken cancellationToken)
    {
        var packageRegisterType = await _packageRegisterTypeRepository.FindByAsync<PackageRegisterTypeResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Package Register Type Have Id {request.Id} Is Not Found");
        return packageRegisterType;
    }
}
