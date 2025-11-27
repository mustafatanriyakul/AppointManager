using AppointManager.Backend.Domain.Enums;
using MediatR;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public record UpdateAppointmentStatusCommand(
            Guid AppointmentId,
            AppointmentStatus Status
        ) : IRequest<Unit>;
}
