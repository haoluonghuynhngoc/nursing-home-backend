using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Application.Features.Appointments.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class GetAppointmentsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAppointmentsQuery, PaginatedResponse<AppointmentResponse>>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    public async Task<PaginatedResponse<AppointmentResponse>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository
            .FindAsync<AppointmentResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await appointments.ToPaginatedResponseAsync();
    }
}
