using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class GetProjectTaskQueryHandler : IRequestHandler<GetProjectTaskQuery, OperationResult<ProjectTaskDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectTaskQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProjectTaskDto>> Handle(GetProjectTaskQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProjectTaskDto>();
            response.Value = await _dbContext.ProjectTasks
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new ProjectTaskDto
                {
                    Id = item.Id,
                    Title = item.Title, StartDate = item.StartDate, EstimatedTime = item.EstimatedTime, Description = item.Description, IsCompleted = item.IsCompleted, FixedPrice = item.FixedPrice
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
