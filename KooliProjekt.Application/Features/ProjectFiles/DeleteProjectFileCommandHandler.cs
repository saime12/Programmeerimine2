using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class DeleteProjectFileCommandHandler : IRequestHandler<DeleteProjectFileCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteProjectFileCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteProjectFileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var entity = await _dbContext.ProjectFiles.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                result.AddError("Kirjet ei leitud.");
                return result;
            }

            _dbContext.ProjectFiles.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
