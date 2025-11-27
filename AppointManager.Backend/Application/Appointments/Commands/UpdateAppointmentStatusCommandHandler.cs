using System.Reflection.Metadata;
using System.Security.Claims;
using AppointManager.Backend.Domain.Enums;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public class UpdateAppointmentStatusCommandHandler : IRequestHandler<UpdateAppointmentStatusCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAppointmentStatusCommandHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(UpdateAppointmentStatusCommand command, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == command.AppointmentId, cancellationToken);

            if (appointment == null)
            {
                throw new Exception($"Appointment with ID {command.AppointmentId} does not exists");
            }

            appointment.Status = command.Status;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
