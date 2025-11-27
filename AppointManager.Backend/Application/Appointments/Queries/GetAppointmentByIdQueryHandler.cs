using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
namespace AppointManager.Backend.Application.Appointments.Queries
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
    {
        private readonly ApplicationDbContext _context;

        public GetAppointmentByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery query, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }


            var appointmentDto = new AppointmentDto
            {
                Id = appointment.Id,
                CustomerName = appointment.CustomerName,
                CompanyName = appointment.CompanyName,
                Date = appointment.Date,
                Notes = appointment.Notes
            };

            return appointmentDto;
        }
    }
}
*/