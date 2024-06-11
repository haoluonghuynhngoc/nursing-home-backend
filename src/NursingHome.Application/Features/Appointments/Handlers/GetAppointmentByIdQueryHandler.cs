using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Application.Features.Appointments.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class GetAppointmentByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAppointmentByIdQuery, AppointmentResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    public async Task<AppointmentResponse> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.FindByAsync<AppointmentResponse>(x => x.Id == request.Id, cancellationToken);

        if (appointment == null)
        {
            throw new NotFoundException(nameof(Appointment), request.Id);
        }

        return appointment;
    }
}
