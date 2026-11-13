
using System.IO;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.ProjectFiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KooliProjekt.WebAPI.Models;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ProjectFilesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new ListProjectFilesQuery
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

            var result = await _mediator.Send(new GetProjectFileQuery
            {
                Id = id.Value
            });

            return Result(result);
        }


        [HttpPost("save")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Save(
            [FromForm] UploadProjectFileRequest request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("Palun vali fail.");
            }

            using (var stream = request.File.OpenReadStream())
            {
                var result = await _mediator.Send(new SaveProjectFileCommand
                {
                    ProjectTaskId = request.ProjectTaskId,
                    FileName = request.File.FileName,
                    InputStream = stream
                });

                return Result(result);
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new DeleteProjectFileCommand
            {
                Id = id
            });

            return Result(result);
        }
    }
}
