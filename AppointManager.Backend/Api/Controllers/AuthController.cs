using AppointManager.Backend.Application.Users.Customers.Commands;
using AppointManager.Backend.Application.Users.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointManager.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);
                return StatusCode(201, new { UserId = userId, Message = "Customer registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
