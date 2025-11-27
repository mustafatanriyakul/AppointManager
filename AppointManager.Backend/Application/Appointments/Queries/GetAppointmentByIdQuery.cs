using MediatR;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public record GetAppointmentByIdQuery(Guid Id) : IRequest<AppointmentDto> { }
}
