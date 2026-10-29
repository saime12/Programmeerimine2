using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class GetProjectTaskQuery : IRequest<OperationResult<ProjectTaskDto>>
    {
        public int Id { get; set; }
    }
}
