using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class SaveProjectTaskCommandHandler : IRequestHandler<SaveProjectTaskCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProjectTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            ProjectTask entity;

            if (request.Id > 0)
            {
                entity = await _dbContext.ProjectTasks.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (entity == null)
                {
                    result.AddError("Kirjet ei leitud.");
                    return result;
                }
            }
            else
            {
                entity = new ProjectTask();
                _dbContext.ProjectTasks.Add(entity);
            }

            entity.Title = request.Title;
            entity.StartDate = request.StartDate;
            entity.EstimatedTime = request.EstimatedTime;
            entity.Description = request.Description;
            entity.IsCompleted = request.IsCompleted;
            entity.FixedPrice = request.FixedPrice;
            await _dbContext.SaveChangesAsync(cancellationToken);
            result.Value = entity.Id;
            return result;
        }
    }
}
