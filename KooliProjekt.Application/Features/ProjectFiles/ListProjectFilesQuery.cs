using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class ListProjectFilesQuery : IRequest<IEnumerable<ProjectFile>>
    {
    }
}
