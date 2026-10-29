using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class GetProjectFileQuery : IRequest<OperationResult<ProjectFileDto>>
    {
        public int Id { get; set; }
    }
}
