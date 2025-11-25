using AppointManager.Backend.Application.Appointments.Commands;
using AppointManager.Backend.Infrastructure.Persistence;
using AppointManager.Backend.Domain.Entities;
using MediatR;


namespace AppointManager.Backend.Application.Appointments.Commands
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>

    {
        private readonly ApplicationDbContext _context;

        public CreateAppointmentCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                CustomerName = request.CustomerName,
                CompanyName = request.CompanyName,
                Date = request.Date.ToUniversalTime(),
                Notes = request.Notes
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync(cancellationToken);

            return appointment.Id;
        }
    }
}
