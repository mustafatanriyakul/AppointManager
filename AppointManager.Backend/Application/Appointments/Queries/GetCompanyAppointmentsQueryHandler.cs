using System.Security.Claims;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Appointments.Queries
{
    public class GetCompanyAppointmentsQueryHandler : IRequestHandler<GetCompanyAppointmentsQuery, List<AppointmentDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCompanyAppointmentsQueryHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AppointmentDto>> Handle(GetCompanyAppointmentsQuery query, CancellationToken cancellationToken)
        {
            var companyAdminId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var companyAdmin = await _context.CompanyAdmins.FirstOrDefaultAsync(ca => ca.UserId == companyAdminId);

            var companyAppointments = await _context.Appointments
                .Where(appointment => appointment.CompanyId == companyAdmin.CompanyId)
                .OrderBy(appointment => appointment.Date)
                .Select(appointment => new AppointmentDto(
                        appointment.Id,
                        appointment.Date,
                        appointment.Notes,
                        appointment.Customer.ApplicationUser.FirstName + " " + appointment.Customer.ApplicationUser.LastName,
                        appointment.Company.Name,
                        appointment.Status.ToString()
                    )).ToListAsync(cancellationToken);

            return companyAppointments;


        }
    }
}
