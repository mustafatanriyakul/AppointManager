using AppointManager.Backend.Application.Appointments.Commands;
using AppointManager.Backend.Application.Appointments.Queries;
using AppointManager.Backend.Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointManager.Backend.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Customer")]
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("appointments")]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
        {
            try
            {
                var id = await _mediator.Send(command); 
                return StatusCode(201, new { AppointmentId = id, Message = "Randevu oluşturuldu" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetCustomerAppointments()
        {
            try
            {
                var query = new GetCustomerAppointmentsQuery();
                var appointments = await _mediator.Send(query);

                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var query = new GetAllCompaniesQuery();
                var companies = await _mediator.Send(query);

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    }
}
