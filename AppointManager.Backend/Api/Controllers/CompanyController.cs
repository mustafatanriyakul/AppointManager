using AppointManager.Backend.Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointManager.Backend.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles ="Customer" + "," + "CompanyAdmin")]
    [ApiController]
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyDetails(Guid id)
        {
            var query = new GetCompanyDetailsQuery(id);
            var companyDetails = await _mediator.Send(query);

            return Ok(companyDetails);
        }
    }
}
