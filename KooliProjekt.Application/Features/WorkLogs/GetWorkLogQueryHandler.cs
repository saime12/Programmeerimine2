using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class GetWorkLogQueryHandler : IRequestHandler<GetWorkLogQuery, OperationResult<WorkLogDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWorkLogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WorkLogDto>> Handle(GetWorkLogQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WorkLogDto>();
            response.Value = await _dbContext.WorkLogs
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new WorkLogDto
                {
                    Id = item.Id,
                    Date = item.Date, TimeSpent = item.TimeSpent, Description = item.Description
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
