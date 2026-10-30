using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class SaveWorkLogCommandHandler : IRequestHandler<SaveWorkLogCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveWorkLogCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveWorkLogCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            WorkLog entity;

            if (request.Id > 0)
            {
                entity = await _dbContext.WorkLogs.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (entity == null)
                {
                    result.AddError("Kirjet ei leitud.");
                    return result;
                }
            }
            else
            {
                entity = new WorkLog();
                _dbContext.WorkLogs.Add(entity);
            }

            entity.Date = request.Date;
            entity.TimeSpent = request.TimeSpent;
            entity.Description = request.Description;
            await _dbContext.SaveChangesAsync(cancellationToken);
            result.Value = entity.Id;
            return result;
        }
    }
}
