using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    internal class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, OperationResult<PagedResult<ProjectDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProjectDto>>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProjectDto>>();
            response.Value = await _dbContext.Projects
                .AsNoTracking()
                .OrderByDescending(item => item.Id)
                .Select(item => new ProjectDto
                {
                    Id = item.Id,
                    ProjectName = item.ProjectName, StartDate = item.StartDate, DeadLine = item.DeadLine, Budget = item.Budget, HourlyRate = item.HourlyRate
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return response;
        }
    }
}
