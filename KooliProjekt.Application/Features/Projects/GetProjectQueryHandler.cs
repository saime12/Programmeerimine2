using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, OperationResult<ProjectDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProjectDto>();
            response.Value = await _dbContext.Projects
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new ProjectDto
                {
                    Id = item.Id,
                    ProjectName = item.ProjectName, StartDate = item.StartDate, DeadLine = item.DeadLine, Budget = item.Budget, HourlyRate = item.HourlyRate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
