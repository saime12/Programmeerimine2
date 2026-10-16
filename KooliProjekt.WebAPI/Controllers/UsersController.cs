using KooliProjekt.Application.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new ListUsersQuery());

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new GetUserQuery
            {
                Id = id.Value
            });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}