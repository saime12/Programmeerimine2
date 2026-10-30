using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteProjectTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var entity = await _dbContext.ProjectTasks.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                result.AddError("Kirjet ei leitud.");
                return result;
            }

            _dbContext.ProjectTasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
