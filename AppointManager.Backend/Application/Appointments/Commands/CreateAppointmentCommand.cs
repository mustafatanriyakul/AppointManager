using MediatR;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public record CreateAppointmentCommand(
            string CustomerName,
            string CompanyName,
            DateTimeOffset Date,
            string Notes
        ) : IRequest<Guid>;
    
}
