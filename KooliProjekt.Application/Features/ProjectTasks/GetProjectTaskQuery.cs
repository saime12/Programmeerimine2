using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class GetProjectTaskQuery : IRequest<ProjectTask>
    {
        public int Id { get; set; }
    }
}
