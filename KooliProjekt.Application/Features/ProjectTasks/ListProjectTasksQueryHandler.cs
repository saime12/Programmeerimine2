using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    internal class ListProjectTasksQueryHandler : IRequestHandler<ListProjectTasksQuery, OperationResult<PagedResult<ProjectTaskDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectTasksQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProjectTaskDto>>> Handle(ListProjectTasksQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProjectTaskDto>>();
            response.Value = await _dbContext.ProjectTasks
                .AsNoTracking()
                .OrderByDescending(item => item.Id)
                .Select(item => new ProjectTaskDto
                {
                    Id = item.Id,
                    Title = item.Title, StartDate = item.StartDate, EstimatedTime = item.EstimatedTime, Description = item.Description, IsCompleted = item.IsCompleted, FixedPrice = item.FixedPrice
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return response;
        }
    }
}
