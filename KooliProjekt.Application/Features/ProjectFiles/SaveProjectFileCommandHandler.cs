using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class SaveProjectFileCommandHandler : IRequestHandler<SaveProjectFileCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProjectFileCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProjectFileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            ProjectFile entity;

            if (request.Id > 0)
            {
                entity = await _dbContext.ProjectFiles.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (entity == null)
                {
                    result.AddError("Kirjet ei leitud.");
                    return result;
                }
            }
            else
            {
                entity = new ProjectFile();
                _dbContext.ProjectFiles.Add(entity);
            }

            entity.FileName = request.FileName;
            entity.FilePath = request.FilePath;
            entity.UploadTime = request.UploadTime;
            await _dbContext.SaveChangesAsync(cancellationToken);
            result.Value = entity.Id;
            return result;
        }
    }
}
