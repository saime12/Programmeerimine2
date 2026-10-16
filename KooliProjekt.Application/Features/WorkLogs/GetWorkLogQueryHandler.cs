using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class GetWorkLogQueryHandler : IRequestHandler<GetWorkLogQuery, WorkLog>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWorkLogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WorkLog> Handle(GetWorkLogQuery request, CancellationToken cancellationToken)
        {
            var workLog = await _dbContext.WorkLogs.FindAsync(request.Id, cancellationToken);

            return workLog;
        }
    }
}
