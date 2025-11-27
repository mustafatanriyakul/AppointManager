using MediatR;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public record DeleteAppointmentByIdCommand(Guid Id) : IRequest<Unit>;
}
