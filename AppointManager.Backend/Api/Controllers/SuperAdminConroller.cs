using AppointManager.Backend.Application.Companies;
using AppointManager.Backend.Application.Users.CompanyAdmins.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointManager.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/superadmin")]
    public class SuperAdminConroller : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuperAdminConroller(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("create/company")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand command)
        {
            var userId = await _mediator.Send(command);

            return Ok(userId);
        }

        [HttpPost("create/company-admin")]
        public async Task<IActionResult> CreateCompanyAdmin(CreateCompanyAdminCommand command)
        {
            var userId = await _mediator.Send(command);

            return Ok(userId);
        }
    }
}
