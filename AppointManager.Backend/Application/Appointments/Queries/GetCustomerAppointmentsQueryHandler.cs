using System.Security.Claims;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public class GetCustomerAppointmentsQueryHandler : IRequestHandler<GetCustomerAppointmentsQuery, List<AppointmentDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCustomerAppointmentsQueryHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AppointmentDto>> Handle(GetCustomerAppointmentsQuery query, CancellationToken cancellationToken)
        {
            var customerId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = await _context.Appointments.ToListAsync(cancellationToken);



            var customerAppointments = await _context.Appointments
                .Where(appointment => appointment.CustomerId == customerId)
                .Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Company)
                .OrderByDescending(appointment => appointment.Date)

                .Select(appointment => new AppointmentDto(
                        appointment.Id,
                        appointment.Date,
                        appointment.Notes,
                        appointment.Customer.ApplicationUser.FirstName + " " + appointment.Customer.ApplicationUser.LastName,
                        appointment.Company.Name,
                        appointment.Status.ToString()
                    )).ToListAsync(cancellationToken);


            return customerAppointments;
        }
    }
}
