using AppointManager.Backend.Application.Appointments.Commands;
using AppointManager.Backend.Application.Appointments.Queries;
using AppointManager.Backend.Application.Companies;
using AppointManager.Backend.Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AppointManager.Backend.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "CompanyAdmin")]
    [ApiController]
    [Route("api/company-admin")]
    public class CompanyAdminController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CompanyAdminController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetCompanyAppointments(){
            var query = new GetCompanyAppointmentsQuery();
            var companyAppointments = await _mediator.Send(query);

            return Ok(companyAppointments);
        }

        [HttpPut("appointments/update")]
        public async Task<IActionResult> UpdateAppointmentStatus(UpdateAppointmentStatusCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("appointments/delete/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            try
            {
                var command = new DeleteAppointmentByIdCommand(id);
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        
        
    }
}
