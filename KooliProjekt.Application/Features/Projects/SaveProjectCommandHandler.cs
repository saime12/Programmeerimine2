using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    public class SaveProjectCommandHandler : IRequestHandler<SaveProjectCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProjectCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProjectCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            Project entity;

            if (request.Id > 0)
            {
                entity = await _dbContext.Projects.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (entity == null)
                {
                    result.AddError("Kirjet ei leitud.");
                    return result;
                }
            }
            else
            {
                entity = new Project();
                _dbContext.Projects.Add(entity);
            }

            entity.ProjectName = request.ProjectName;
            entity.StartDate = request.StartDate;
            entity.DeadLine = request.DeadLine;
            entity.Budget = request.Budget;
            entity.HourlyRate = request.HourlyRate;
            await _dbContext.SaveChangesAsync(cancellationToken);
            result.Value = entity.Id;
            return result;
        }
    }
}
