using MediatR;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public record GetCustomerAppointmentsQuery : IRequest<List<AppointmentDto>> { }
}
