using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public class DeleteAppointmentByIdCommandHandler : IRequestHandler<DeleteAppointmentByIdCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteAppointmentByIdCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAppointmentByIdCommand command, CancellationToken cancellationToken)
        {

            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

            if (appointment == null)
            {
                throw new Exception($"Appointment with ID {command.Id} does not exists");
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
