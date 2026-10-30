using MediatR;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.Projects
{
    public class DeleteProjectCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
