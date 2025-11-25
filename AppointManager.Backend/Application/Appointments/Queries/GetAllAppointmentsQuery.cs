using MediatR;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public record GetAllAppointmentsQuery : IRequest<List<AppointmentDto>> { }
}
