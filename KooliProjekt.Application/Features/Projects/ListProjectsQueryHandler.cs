using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    internal class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, IEnumerable<Project>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Projects.ToListAsync(cancellationToken);

            return result;
        }
    }
}
