using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegister.Models;
using NursingHome.Application.Features.PackageRegister.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegister.Handlers;
internal sealed class GetPackageRegisterByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPackageRegisterByIdQuery, PackageRegisterResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<PackageRegisterResponse> Handle(GetPackageRegisterByIdQuery request, CancellationToken cancellationToken)
    {
        var packageSubscription = await _packageRepository.FindByAsync<PackageRegisterResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Package Register Have Id {request.Id} Is Not Found");
        return packageSubscription;
    }
}
