using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WorkLogs
{
    internal class ListWorkLogsQueryHandler : IRequestHandler<ListWorkLogsQuery, IEnumerable<WorkLog>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorkLogsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkLog>> Handle(ListWorkLogsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WorkLogs.ToListAsync(cancellationToken);

            return result;
        }
    }
}
