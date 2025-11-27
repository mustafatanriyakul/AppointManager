using MediatR;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public record GetCompanyAppointmentsQuery : IRequest<List<AppointmentDto>> { }
    
}
