using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class GetProjectQuery : IRequest<Project>
    {
        public int Id { get; set; }
    }
}
