using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Projects
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FindAsync(request.Id, cancellationToken);

            return project;
        }
    }
}
