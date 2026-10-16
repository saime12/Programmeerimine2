using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class ListProjectTasksQuery : IRequest<IEnumerable<ProjectTask>>
    {
    }
}
