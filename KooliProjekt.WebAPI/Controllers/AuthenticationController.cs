
using KooliProjekt.Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(
            [FromBody] AuthenticateCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
