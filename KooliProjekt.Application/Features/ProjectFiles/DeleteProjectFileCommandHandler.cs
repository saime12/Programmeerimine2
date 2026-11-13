
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class DeleteProjectFileCommandHandler :
        IRequestHandler<DeleteProjectFileCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public DeleteProjectFileCommandHandler(
            ApplicationDbContext dbContext,
            IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(
            DeleteProjectFileCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var entity = await _dbContext.ProjectFiles
                .FirstOrDefaultAsync(
                    item => item.Id == request.Id,
                    cancellationToken);

            if (entity == null)
            {
                result.AddError("Faili ei leitud.");
                return result;
            }

            await _fileClient.Delete(entity.FilePath);

            _dbContext.ProjectFiles.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
