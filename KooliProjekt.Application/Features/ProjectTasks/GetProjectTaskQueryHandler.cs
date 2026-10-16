using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class GetProjectTaskQueryHandler : IRequestHandler<GetProjectTaskQuery, ProjectTask>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectTaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectTask> Handle(GetProjectTaskQuery request, CancellationToken cancellationToken)
        {
            var projectTask = await _dbContext.ProjectTasks.FindAsync(request.Id, cancellationToken);

            return projectTask;
        }
    }
}
