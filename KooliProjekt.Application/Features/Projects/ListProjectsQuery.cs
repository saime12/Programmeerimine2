using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class ListProjectsQuery : IRequest<IEnumerable<Project>>
    {
    }
}
