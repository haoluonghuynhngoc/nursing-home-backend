using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServices.Models;
using NursingHome.Application.Features.PackageServices.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageServices.Handlers;
internal sealed class GetPackageServiceByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPackageServiceByIdQuery, PackageServiceResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<PackageServiceResponse> Handle(GetPackageServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var packageSubscription = await _packageRepository.FindByAsync<PackageServiceResponse>(x => x.Id == request.Id)
        ?? throw new NotFoundException($"Package Service Have Id {request.Id} Is Not Found");
        return packageSubscription;
    }
}
