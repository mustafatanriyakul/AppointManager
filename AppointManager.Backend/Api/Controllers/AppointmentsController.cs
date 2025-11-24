using Microsoft.EntityFrameworkCore;
using MediatR;
using AppointManager.Backend.Application.Appointments.Commands;
using Microsoft.AspNetCore.Mvc;




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
            command.Date = command.Date.ToUniversalTime();
            var id = await _mediator.Send(command);

            return Ok(new { Id = id });
        }
    }
}
