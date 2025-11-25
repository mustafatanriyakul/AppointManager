using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAppointmentsQueryHandler(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<List<AppointmentDto>> Handle(GetAllAppointmentsQuery query, CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointments.ToListAsync(cancellationToken);

            var result = appointments.Select(appointment => new AppointmentDto
            {
                Id = appointment.Id,
                CustomerName = appointment.CustomerName,
                CompanyName = appointment.CompanyName,
                Date = appointment.Date,
                Notes = appointment.Notes,
            }).ToList();


            return result;
        }
    }
}
