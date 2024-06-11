using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Features.PackageFeature.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class GetPackageByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPackageByIdQuery, PackageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<PackageResponse> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
    {
        var package = await _packageRepository.FindByAsync<PackageResponse>(x => x.Id == request.Id, cancellationToken);
        if (package == null)
        {
            throw new NotFoundException(nameof(Package), request.Id);
        }

        return package;

    }
}
