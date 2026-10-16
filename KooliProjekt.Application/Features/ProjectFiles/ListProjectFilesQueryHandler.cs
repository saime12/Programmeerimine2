using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    internal class ListProjectFilesQueryHandler : IRequestHandler<ListProjectFilesQuery, IEnumerable<ProjectFile>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectFilesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProjectFile>> Handle(ListProjectFilesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProjectFiles.ToListAsync(cancellationToken);

            return result;
        }
    }
}
