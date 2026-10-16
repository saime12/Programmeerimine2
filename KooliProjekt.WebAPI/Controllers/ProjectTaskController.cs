using KooliProjekt.Application.Features.ProjectTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ProjectTasksController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new ListProjectTasksQuery());

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new GetProjectTaskQuery
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