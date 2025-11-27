using MediatR;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public record CreateAppointmentCommand(
            Guid CompanyId,
            DateTimeOffset Date,
            string Notes
        ) : IRequest<Guid>;
    
}
