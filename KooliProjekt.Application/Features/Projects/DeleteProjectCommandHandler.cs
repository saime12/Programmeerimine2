using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Projects
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteProjectCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var entity = await _dbContext.Projects.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                result.AddError("Kirjet ei leitud.");
                return result;
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
