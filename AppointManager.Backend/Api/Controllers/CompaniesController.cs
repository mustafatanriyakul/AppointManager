using AppointManager.Backend.Application.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointManager.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CompaniesController(IMediator mediator) 
        {
            _mediator = mediator;
        }


        
    }
}
