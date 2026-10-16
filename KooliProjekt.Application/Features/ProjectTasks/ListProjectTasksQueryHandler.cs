using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    internal class ListProjectTasksQueryHandler : IRequestHandler<ListProjectTasksQuery, IEnumerable<ProjectTask>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectTasksQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProjectTask>> Handle(ListProjectTasksQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProjectTasks.ToListAsync(cancellationToken);

            return result;
        }
    }
}
