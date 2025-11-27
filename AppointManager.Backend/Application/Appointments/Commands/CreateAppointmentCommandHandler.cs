using System.Security.Claims;
using AppointManager.Backend.Application.Appointments.Commands;
using AppointManager.Backend.Domain.Entities;
using AppointManager.Backend.Domain.Enums;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AppointManager.Backend.Application.Appointments.Commands
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>

    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAppointmentCommandHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var customerId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (command.Date <= DateTimeOffset.Now)
            {
                throw new Exception("Geçmiş tarihe randevu alamazsınız.");
            }

            var isConflicting = await _context.Appointments.AnyAsync(appointment =>
                appointment.Date == command.Date && appointment.Status != AppointmentStatus.Cancelled
                &&
                (appointment.CompanyId == command.CompanyId || appointment.CustomerId == customerId),
                cancellationToken);

            if (isConflicting)
            {
                throw new Exception("Seçtiğiniz tarihte zaten sizin veya firmanın başka bir randevusu var.");
            }

            


            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                CompanyId = command.CompanyId,
                Date = command.Date.ToUniversalTime(),
                Notes = command.Notes,
                Status = AppointmentStatus.Pending
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync(cancellationToken);

            return appointment.Id;
        }
    }
}
