using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class GetProjectFileQuery : IRequest<ProjectFile>
    {
        public int Id { get; set; }
    }
}
