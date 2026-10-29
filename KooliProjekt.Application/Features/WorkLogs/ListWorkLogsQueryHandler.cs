using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WorkLogs
{
    internal class ListWorkLogsQueryHandler : IRequestHandler<ListWorkLogsQuery, OperationResult<PagedResult<WorkLogDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorkLogsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WorkLogDto>>> Handle(ListWorkLogsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<WorkLogDto>>();
            response.Value = await _dbContext.WorkLogs
                .AsNoTracking()
                .OrderByDescending(item => item.Id)
                .Select(item => new WorkLogDto
                {
                    Id = item.Id,
                    Date = item.Date, TimeSpent = item.TimeSpent, Description = item.Description
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return response;
        }
    }
}
