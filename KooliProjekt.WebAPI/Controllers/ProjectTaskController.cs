using KooliProjekt.Application.Features.ProjectTasks;
using MediatR;
using KooliProjekt.Application.Features.Projects;
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
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new ListProjectTasksQuery
            {
                Page = page,
                PageSize = pageSize
            });

            return Result(result);
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

            return Result(result);
        }
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveProjectTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new DeleteProjectTaskCommand
            {
                Id = id
            });

            return Result(result);
        }
    }
}
