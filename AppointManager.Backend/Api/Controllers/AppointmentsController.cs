using Microsoft.EntityFrameworkCore;
using MediatR;
using AppointManager.Backend.Application.Appointments.Commands;
using Microsoft.AspNetCore.Mvc;
using AppointManager.Backend.Application.Appointments.Queries;




namespace AppointManager.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            var appointments = await _mediator.Send(query);

            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var query = new GetAppointmentByIdQuery(id);

            try
            {
                var appointment = await _mediator.Send(query);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentById(Guid id)
        {
            try
            {
                var command = new DeleteAppointmentByIdCommand(id);

                await _mediator.Send(command);

                return NoContent();
            }

            catch(Exception ex)  
            {
                return NotFound(ex.Message);
            }

        }
    }
}
