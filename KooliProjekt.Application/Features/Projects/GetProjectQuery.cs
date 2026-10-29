using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class GetProjectQuery : IRequest<OperationResult<ProjectDto>>
    {
        public int Id { get; set; }
    }
}
